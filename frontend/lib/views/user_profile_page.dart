import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:frontend/classes/complaint.dart';
import 'package:frontend/cubits/complaints_cubit/complaints_cubit.dart';
import 'package:frontend/views/complaint/make_complaint_page.dart';
import 'package:frontend/widgets/complaint_item_widget.dart';

class UserProfilePage extends StatefulWidget {
  const UserProfilePage({super.key});

  @override
  // ignore: library_private_types_in_public_api
  _UserProfilePageState createState() => _UserProfilePageState();
}

class _UserProfilePageState extends State<UserProfilePage>
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
    return Scaffold(
      bottomNavigationBar: const BottomAppBar(
          color: Colors.white,
          height: 50,
          child: Center(
              child: Stack(
            fit: StackFit.passthrough,
            children: [
              Text("©Kolejna Podróż 2024",
                  style: TextStyle(color: Colors.black)),
            ],
          ))),
      appBar: AppBar(
        title: const  Stack(
          alignment: AlignmentDirectional.centerEnd,
          children:[ 
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
              padding:
                  const EdgeInsets.symmetric(horizontal: 300, vertical: 100),
              child: Container(
                width: MediaQuery.of(context).size.width,
                constraints: const BoxConstraints(maxWidth: 1200),
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
                     const Text("Moje konto",
                          style: TextStyle(
                              fontSize: 24,
                              fontWeight: FontWeight.w600,
                              color: Colors.white)),
                      SizedBox(height: MediaQuery.of(context).size.height * 0.05),
                      Container(
                       decoration:  BoxDecoration(
                            borderRadius:
                               const BorderRadius.all(Radius.circular(10)),
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
                          padding: const EdgeInsets.symmetric(horizontal: 2, vertical: 2),
                          dividerHeight: 0,
                          controller: _tabController,
                          indicatorColor: Colors.orange[700],
                          labelColor: Colors.orange[700],
                          tabs:  [
                            Tab(
                                text: 'Dane użytkownika',
                                icon: Icon(
                                  Icons.person,
                                  color: Colors.grey.shade500.withOpacity(0.9),
                                )),
                            Tab(
                                text: 'Bilety',
                                icon: Icon(
                                  Icons.train,
                                  color: Colors.grey.shade500.withOpacity(0.9),
                                )),
                            Tab(
                                text: 'Reklamacje',
                                icon: Icon(
                                  Icons.sentiment_very_dissatisfied,
                                  color: Colors.grey.shade500.withOpacity(0.9),
                                )),
                            Tab(
                                text: 'Statystyki',
                                icon: Icon(
                                  Icons.bar_chart,
                                  color: Colors.grey.shade500.withOpacity(0.9),
                                )),
                            Tab(
                                text: 'Osiągnięcia' ,
                                icon: Icon(
                                  Icons.star,
                                  color: Colors.grey.shade500.withOpacity(0.9),
                                )),
                          ],
                        ),
                      ),
                      // Zmniejszone szare tło dla TabBarView
                      Expanded(
                        child: Container(
                          // Mniejsza wysokość tła
                          padding: const EdgeInsets.all(20),
                          height: MediaQuery.of(context).size.height * 0.5,
                          decoration: BoxDecoration(
                            borderRadius:
                               const BorderRadius.all(Radius.circular(15)),
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
                              UserInfoPage(),
                              TicketsPage(),
                              ComplaintsPage(),
                              StatisticsPage(),
                              AchievementsPage(),
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

class ComplaintsPage extends StatelessWidget {
  const ComplaintsPage({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold( 
      appBar: AppBar(
        title: const Center(child:  Text('Reklamacje')),
        backgroundColor: Colors.transparent,
        elevation: 0,
      ),
      body:
      ListView(
        children: [
          Container(
            margin: const EdgeInsets.only(top: 50, bottom: 20),
            child: const Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Text(
                  "Wszystkie reklamacje",
                  style: TextStyle(fontSize: 30, fontWeight: FontWeight.w500),
                ),
              ],
            ),
          ),
          for (Complaint c in cmps) complaint_item(complaint: c),
        const  SizedBox(
            height: 75,
          ),
        ],
      ));
  }
}

class UserInfoPage extends StatelessWidget {
  const UserInfoPage({super.key});

  @override
  Widget build(BuildContext context) {
    return const Center(child: Text('Dane użytkownika'));
  }
}

class TicketsPage extends StatelessWidget {
  TicketsPage({super.key});

  String ticket = "Bilet nr2137";
  @override
  Widget build(BuildContext context) {
    return Center(
        child: ListView(
      children: [
        TextButton(
          child: Text(ticket),
          onPressed: () {
            Navigator.of(context).push(
                MaterialPageRoute(
                  builder: (context) => MakeComplaintPage(ticketId: ticket),
                  ),
                );
          },
        )
      ],
    ));
  }
}

class StatisticsPage extends StatelessWidget {
  const StatisticsPage({super.key});

  @override
  Widget build(BuildContext context) {
    return const Center(child: Text('Statystyki'));
  }
}

class AchievementsPage extends StatelessWidget {
  const AchievementsPage({super.key});

  @override
  Widget build(BuildContext context) {
    return const Center(child: Text('Osiągnięcia'));
  }
}

List<Complaint> cmps = [
  Complaint(ticketId: "1", content: "lol", isResponded: true),
  Complaint(ticketId: "2", content: "lol2", isResponded: false),
  Complaint(ticketId: "3", content: "lol3", isResponded: false)
];
