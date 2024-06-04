import 'package:admin/classes/admin.dart';
import 'package:admin/classes/user.dart';
import 'package:admin/views/admin/edit_admin_page.dart';
import 'package:admin/views/provider/edit_provider_page.dart';
import 'package:flutter/material.dart';
import 'package:admin/classes/complaint.dart';
import 'package:admin/classes/admin_provider.dart';
import 'package:admin/classes/my_provider.dart';
import 'package:admin/utils/http_requests.dart';
import 'package:admin/views/complaint/review_complaint_page.dart';
import 'package:provider/provider.dart';
import 'package:admin/views/user_profile_subpages/edit_user_page.dart';

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
      appBar: AppBar(),
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
          complaints.removeWhere((element) => element.isResponded == true);
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

class UsersPage extends StatefulWidget {
  UsersPage({Key? key}) : super(key: key);

  @override
  _UsersPageState createState() => _UsersPageState();
}

class _UsersPageState extends State<UsersPage> {
  late Future<List<MyUser>?> _usersFuture;
  HttpRequests request = HttpRequests();
  @override
  void initState() {
    super.initState();
    _usersFuture = _fetchUsers();
  }

  Future<List<MyUser>?> _fetchUsers() async {
    return request.getAllUsers();
  }

  @override
  Widget build(BuildContext context) {
    return FutureBuilder<List<MyUser>?>(
      future: _usersFuture,
      builder: (BuildContext context, AsyncSnapshot<List<MyUser>?> snapshot) {
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
          List<MyUser> users = snapshot.data!;

          return ListView.builder(
            itemCount: users.length,
            itemBuilder: (context, index) {
              final user = users[index];
              return ListTile(
                title: Text(user.firstName! + " " + user.lastName!),
                subtitle: Text(user.id.toString()),
                trailing: Row(
                  mainAxisSize: MainAxisSize.min,
                  children: [
                    IconButton(
                      icon: Icon(Icons.check),
                      onPressed: () {
                        // Navigator to edit complaint page
                        Navigator.of(context).push(
                          MaterialPageRoute(
                            builder: (context) => EditUserPage(user: user),
                          ),
                        );
                      },
                    ),
                    IconButton(
                      icon: Icon(Icons.delete),
                      onPressed: () async {
                        await request.deleteUser(user.id);
                      },
                    ),
                  ],
                ),
              );
            },
          );
        } else {
          // Handling the case where there are no complaints
          return Center(child: Text('No users to display'));
        }
      },
    );
  }
}

class ProvidersPage extends StatefulWidget {
  ProvidersPage({Key? key}) : super(key: key);

  @override
  _ProvidersPageState createState() => _ProvidersPageState();
}

class _ProvidersPageState extends State<ProvidersPage> {
  late Future<List<MyProvider>?> _providersFuture;
  HttpRequests request = HttpRequests();
  @override
  void initState() {
    super.initState();
    _providersFuture = _fetchProviders();
  }

  Future<List<MyProvider>?> _fetchProviders() async {
    return request.getAllProviders();
  }

  @override
  Widget build(BuildContext context) {
    return FutureBuilder<List<MyProvider>?>(
      future: _providersFuture,
      builder:
          (BuildContext context, AsyncSnapshot<List<MyProvider>?> snapshot) {
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
          List<MyProvider> providers = snapshot.data!;

          return Column(
            children: [
              ListView.builder(
                itemCount: providers.length,
                itemBuilder: (context, index) {
                  final provider = providers[index];
                  return ListTile(
                    title: Text(provider.name),
                    subtitle: Text(provider.id.toString()),
                    trailing: Row(
                      mainAxisSize: MainAxisSize.min,
                      children: [
                        IconButton(
                          icon: Icon(Icons.check),
                          onPressed: () {
                            // Navigator to edit complaint page
                            Navigator.of(context).push(
                              MaterialPageRoute(
                                builder: (context) =>
                                    EditProviderPage(provider: provider),
                              ),
                            );
                          },
                        ),
                        IconButton(
                          icon: Icon(Icons.delete),
                          onPressed: () async {
                            // Navigator to edit complaint page
                            await request
                                .deleteProvider(provider.id.toString());
                          },
                        ),
                      ],
                    ),
                  );
                },
              ),
              Center(
                child: ElevatedButton(
                  onPressed: () async {
                    MyProvider p =
                        MyProvider(name: "", info: "", email: "", id: 1);
                    Map<String, dynamic> newData = {
                      'name': p.name,
                      'info': p.info,
                      'email': p.email,
                      'id': p.id
                    };
                    await request.addProvider(p.id.toString(), newData);

                    Navigator.of(context).push(MaterialPageRoute(
                        builder: (context) => EditProviderPage(provider: p)));
                  },
                  child: Text("Dodaj nowego przewoźnika"),
                ),
              )
            ],
          );
        } else {
          // Handling the case where there are no complaints
          return Center(child: Text('No providers to display'));
        }
      },
    );
  }
}

class DatabasePage extends StatelessWidget {
  DatabasePage({super.key});

  @override
  Widget build(BuildContext context) {
    return Center(child: Text('DB'));
  }
}

class AdminsPage extends StatefulWidget {
  AdminsPage({Key? key}) : super(key: key);

  @override
  _AdminsPageState createState() => _AdminsPageState();
}

class _AdminsPageState extends State<AdminsPage> {
  late Future<List<MyAdmin>?> _adminsFuture;
  HttpRequests request = HttpRequests();
  @override
  void initState() {
    super.initState();
    _adminsFuture = _fetchAdmins();
  }

  Future<List<MyAdmin>?> _fetchAdmins() async {
    return request.getAllAdmins();
  }

  @override
  Widget build(BuildContext context) {
    return FutureBuilder<List<MyAdmin>?>(
      future: _adminsFuture,
      builder: (BuildContext context, AsyncSnapshot<List<MyAdmin>?> snapshot) {
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
          List<MyAdmin> admins = snapshot.data!;
          admins.removeWhere((e) => e.verified == true);
          return Column(
            children: [
              ListView.builder(
                itemCount: admins.length,
                itemBuilder: (context, index) {
                  final admin = admins[index];
                  return ListTile(
                    title: Text(admin.id.toString()),
                    trailing: Row(
                      mainAxisSize: MainAxisSize.min,
                      children: [
                        IconButton(
                          icon: Icon(Icons.check),
                          onPressed: () {
                            // Navigator to edit complaint page
                            Navigator.of(context).push(
                              MaterialPageRoute(
                                  builder: (context) =>
                                      EditAdminPage(admin: admin)),
                            );
                          },
                        ),
                        IconButton(
                          icon: Icon(Icons.delete),
                          onPressed: () async {
                            // Navigator to edit complaint page
                            await request.deleteAdmin(admin.id.toString());
                          },
                        ),
                      ],
                    ),
                  );
                },
              ),
            ],
          );
        } else {
          // Handling the case where there are no complaints
          return Center(child: Text('No admins to display'));
        }
      },
    );
  }
}
