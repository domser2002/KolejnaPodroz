

import 'package:flutter/material.dart';
import 'package:frontend/classes/complaint.dart';
import 'package:frontend/classes/user_provider.dart';
import 'package:frontend/utils/http_requests.dart';
import 'package:frontend/views/complaint/edit_complaint_page.dart';
import 'package:provider/provider.dart';

class ComplaintsPage extends StatefulWidget {
  ComplaintsPage({Key? key}) : super(key: key);

  @override
  _ComplaintsPageState createState() => _ComplaintsPageState();
}

class _ComplaintsPageState extends State<ComplaintsPage> {
  late Future<List<Complaint>> _complaintsFuture;

  @override
  void initState() {
    super.initState();
    _complaintsFuture = _fetchComplaints();
  }

  Future<List<Complaint>> _fetchComplaints() async {
    int userId = Provider.of<UserProvider>(context, listen: false).user!.id;
    HttpRequests request = HttpRequests();

    return request.getComplaintsByUser(userId);
  }

  void _removeComplaint(String complaintId) async {
    HttpRequests request = HttpRequests();
    await request.removeComplaint(complaintId);
    setState(() {
      // Ponowne pobranie listy reklamacji po usunięciu reklamacji
      _complaintsFuture = _fetchComplaints();
    });
  }

  @override
  Widget build(BuildContext context) {
    return FutureBuilder<List<Complaint>>(
      future: _complaintsFuture,
      builder: (BuildContext context, AsyncSnapshot<List<Complaint>> snapshot) {
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
          List<Complaint> complaints = snapshot.data!;
          return ListView.builder(
            itemCount: complaints.length,
            itemBuilder: (context, index) {
              final complaint = complaints[index];
              return ListTile(
                title: Text(complaint.title),
                subtitle: Text(complaint.content),
                trailing: Row(
                  mainAxisSize: MainAxisSize.min,
                  children: [
                    IconButton(
                      icon: const Icon(Icons.edit),
                      onPressed: () {
                        // Navigator to edit complaint page
                        Navigator.of(context).push(
                          MaterialPageRoute(
                            builder: (context) => EditComplaintPage(complaintId: complaint.id),
                          ),
                        );
                      },
                    ),
                    IconButton(
                      icon: const  Icon(Icons.delete),
                      onPressed: () {
                        _removeComplaint(complaint.id.toString());
                      },
                    ),
                  ],
                ),
              );
            },
          );
        } else {
          // Handling the case where there are no complaints
          return const Center(child: Text('Brak reklamacji do wyświetlenia'));
        }
      },
    );
  }
}
