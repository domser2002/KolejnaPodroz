import 'package:flutter/material.dart';
import 'package:admin/classes/complaint.dart';
import 'package:admin/classes/admin_provider.dart';
import 'package:admin/utils/http_requests.dart';
import 'package:admin/views/complaint/review_complaint_page.dart';
import 'package:provider/provider.dart';

class AdminProfilePage extends StatefulWidget {
  AdminProfilePage({super.key});

  @override
  // ignore: library_private_types_in_public_api
  _AdminProfilePageState createState() => _AdminProfilePageState();
}

class _AdminProfilePageState extends State<AdminProfilePage>
    with TickerProviderStateMixin {
  late TabController _tabController;

  @override
  void initState() {
    super.initState();
    _tabController = TabController(length: 5, vsync: this);
  }

  @override
  void dispose() {
    _tabController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    Size screenSize = MediaQuery.of(context).size;
    double win_width = screenSize.width;
    double win_height = screenSize.height;

    return Scaffold(
      bottomNavigationBar: BottomAppBar(
          color: Colors.white,
          height: win_height * 0.07,
          child: const Center(
              child: Stack(
            fit: StackFit.passthrough,
            children: [
              Text("©Kolejna Podróż 2024",
                  style: TextStyle(color: Colors.black)),
            ],
          ))),
      appBar: AppBar(
        title:
            const Stack(alignment: AlignmentDirectional.centerEnd, children: [
          Icon(Icons.person, size: 40, color: Colors.black),
        ]),
        backgroundColor: Colors.white,
        elevation: 0,
      ),
      extendBodyBehindAppBar: true,
      body: Stack(
        children: [
          // Tło
          Positioned.fill(
            child: Image.asset(
              'lib/assets/photos/background2.jpg',
              fit: BoxFit.cover,
            ),
          ),
          // Zawartość główna
          Center(
            child: Padding(
              padding: EdgeInsets.symmetric(
                  horizontal: win_width * 0.2, vertical: win_height * 0.14),
              child: Container(
                width: win_width,
                constraints: BoxConstraints(maxWidth: win_width * 0.78),
                decoration: BoxDecoration(
                  borderRadius: BorderRadius.circular(10),
                  gradient: LinearGradient(
                    begin: Alignment.topCenter,
                    end: Alignment.bottomCenter,
                    colors: [
                      Colors.blueAccent.shade700.withOpacity(0.9),
                      Colors.blueAccent.shade400.withOpacity(0.9),
                      Colors.blueAccent.shade200.withOpacity(0.9),
                      Colors.blueAccent.shade100.withOpacity(0.9),
                    ],
                  ),
                ),
                child: Card(
                  color: Colors.transparent,
                  elevation: 8,
                  shape: RoundedRectangleBorder(
                      borderRadius: BorderRadius.circular(40)),
                  child: Column(
                    children: [
                      const Text("Admin Actions",
                          style: TextStyle(
                              fontSize: 24,
                              fontWeight: FontWeight.w600,
                              color: Colors.white)),
                      SizedBox(height: win_height * 0.05),
                      Container(
                        decoration: BoxDecoration(
                          borderRadius: BorderRadius.all(Radius.circular(10)),
                          gradient: LinearGradient(
                            begin: Alignment.topCenter,
                            end: Alignment.bottomCenter,
                            colors: [
                              Colors.white,
                              Colors.grey.shade100.withOpacity(0.9),
                            ],
                          ),
                        ),
                        height: 65,
                        width: 800,
                        child: TabBar(
                          indicatorWeight: 4,
                          padding:
                              EdgeInsets.symmetric(horizontal: 2, vertical: 2),
                          dividerHeight: 0,
                          controller: _tabController,
                          indicatorColor: Colors.orange[700],
                          labelColor: Colors.orange[700],
                          tabs: [
                            Tab(
                                text: 'Przewoźnicy',
                                icon: Icon(
                                  Icons.train,
                                  color: Colors.grey.shade500.withOpacity(0.9),
                                )),
                            Tab(
                                text: 'Użytkownicy',
                                icon: Icon(
                                  Icons.person,
                                  color: Colors.grey.shade500.withOpacity(0.9),
                                )),
                            Tab(
                                text: 'Reklamacje',
                                icon: Icon(
                                  Icons.sentiment_very_dissatisfied,
                                  color: Colors.grey.shade500.withOpacity(0.9),
                                )),
                            Tab(
                                text: 'Administratorzy',
                                icon: Icon(
                                  Icons.card_membership,
                                  color: Colors.grey.shade500.withOpacity(0.9),
                                )),
                            Tab(
                                text: 'Baza danych',
                                icon: Icon(
                                  Icons.book,
                                  color: Colors.grey.shade500.withOpacity(0.9),
                                )),
                          ],
                        ),
                      ),
                      // Zmniejszone szare tło dla TabBarView
                      Expanded(
                        child: Container(
                          // Mniejsza wysokość tła
                          padding: EdgeInsets.all(20),
                          height: win_height * 0.5,
                          decoration: BoxDecoration(
                            borderRadius: BorderRadius.all(Radius.circular(15)),
                            gradient: LinearGradient(
                              begin: Alignment.topCenter,
                              end: Alignment.bottomCenter,
                              colors: [
                                Colors.grey.shade100.withOpacity(0.9),
                                Colors.white
                              ],
                            ),
                          ),
                          child: TabBarView(
                            controller: _tabController,
                            children: [
                              ProvidersPage(),
                              UsersPage(),
                              ComplaintsPage(),
                              AdminsPage(),
                              DatabasePage(),
                            ],
                          ),
                        ),
                      ),
                    ],
                  ),
                ),
              ),
            ),
          ),
        ],
      ),
    );
  }
}

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
    HttpRequests request = HttpRequests();

    return request.getAllComplaints();
  }

  @override
  Widget build(BuildContext context) {
    return FutureBuilder<List<Complaint>>(
      future: _complaintsFuture,
      builder: (BuildContext context, AsyncSnapshot<List<Complaint>> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          // While the future is executing, show a loading indicator
          return Center(
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
                      icon: Icon(Icons.check),
                      onPressed: () {
                        // Navigator to edit complaint page
                        Navigator.of(context).push(
                          MaterialPageRoute(
                            builder: (context) => ReviewComplaintPage(
                              complaintId: complaint.id,
                              title: complaint.title,
                              reason: complaint.content,
                            ),
                          ),
                        );
                      },
                    ),
                  ],
                ),
              );
            },
          );
        } else {
          // Handling the case where there are no complaints
          return Center(child: Text('No complaints to display'));
        }
      },
    );
  }
}

class UsersPage extends StatelessWidget {
  UsersPage({super.key});

  String ticket = "Bilet nr 2137";
  @override
  Widget build(BuildContext context) {
    return Center(
        child: ListView(
      children: [
        TextButton(
          child: Text(ticket),
          onPressed: () {},
        )
      ],
    ));
  }
}

class ProvidersPage extends StatelessWidget {
  ProvidersPage({super.key});

  @override
  Widget build(BuildContext context) {
    return Center(child: Text('Providers'));
  }
}

class DatabasePage extends StatelessWidget {
  DatabasePage({super.key});

  @override
  Widget build(BuildContext context) {
    return Center(child: Text('DB'));
  }
}

class AdminsPage extends StatelessWidget {
  AdminsPage({super.key});

  @override
  Widget build(BuildContext context) {
    return Center(child: Text('Admin'));
  }
}
