import 'package:flutter/material.dart';
import 'package:frontend/classes/ticket.dart';
import 'package:frontend/classes/user_provider.dart';
import 'package:frontend/utils/http_requests.dart';
import 'package:frontend/views/complaint/make_complaint_page.dart';
import 'package:provider/provider.dart';

class TicketsPage extends StatefulWidget {
  TicketsPage({Key? key}) : super(key: key);

  @override
  _TicketsPageState createState() => _TicketsPageState();
}

class _TicketsPageState extends State<TicketsPage> {
  late Future<List<Ticket>> _ticketsFuture;

  @override
  void initState() {
    super.initState();
    _ticketsFuture = _fetchTickets();
  }

  Future<List<Ticket>> _fetchTickets() async {
    int userId = Provider.of<UserProvider>(context, listen: false).user!.id;
    HttpRequests request = HttpRequests();

    return request.getTicketsByUser(userId);
  }

  @override
  Widget build(BuildContext context) {
    return FutureBuilder<List<Ticket>>(
      future: _ticketsFuture,
      builder: (BuildContext context, AsyncSnapshot<List<Ticket>> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          // While the future is executing, show a loading indicator
          return const Center(
            child: CircularProgressIndicator(),
          );
        } else if (snapshot.hasError) {
          // If there's an error, display an error message
          return Center(
            child: Text('Error: ${snapshot.error.toString()}'),
          );
        } else if (snapshot.hasData && snapshot.data!.isNotEmpty) {
          // Accessing data if the snapshot has data and it is not empty
          List<Ticket> tickets = snapshot.data!;
          return ListView.builder(
            itemCount: tickets.length,
            itemBuilder: (context, index) {
              final ticket = tickets[index];
              return ListTile(
                title: Text('Bilet nr ${ticket.id}'),
                subtitle: Text('Połączenie nr ${ticket.connectionID}'),
                onTap: () {
                  // Navigator to make complaint page
                  Navigator.of(context).push(
                    MaterialPageRoute(
                      builder: (context) => MakeComplaintPage(ticketId: ticket.id.toString()),
                    ),
                  );
                },
              );
            },
          );
        } else {
          // Handling the case where there are no tickets
          return const Center(child: Text('No tickets to display'));
        }
      },
    );
  }
}