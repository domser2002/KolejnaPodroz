import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:frontend/classes/complaint.dart';
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
                      Container(
                        width: 800,

                        color: Colors.grey[400], // Tło dla zakładek Tab
                        child: TabBar(
                          indicatorWeight: 4,
                          padding: const EdgeInsets.symmetric(horizontal: 2, vertical: 2),
                          dividerHeight: 0,
                          controller: _tabController,
                            Tab(
                                text: 'Dane użytkownika',
                                icon: Icon(
                                  Icons.person,
                                )),
                            Tab(
                                text: 'Bilety',
                                icon: Icon(
                                )),
                            Tab(
                                text: 'Reklamacje',
                                icon: Icon(
                                  Icons.sentiment_very_dissatisfied,
                                )),
                            Tab(
                                text: 'Statystyki',
                                icon: Icon(
                                  Icons.bar_chart,
                                )),
                            Tab(
                                icon: Icon(
                                  Icons.star,
                                )),
                          ],
                        ),
                      ),
                      // Zmniejszone szare tło dla TabBarView
                      Expanded(
                        child: Container(
                          // Mniejsza wysokość tła
                          padding: const EdgeInsets.all(20),
                          decoration: BoxDecoration(
                            color: Colors.grey[400], // Szare tło dla TabBarView
                            borderRadius:
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
                      children: [
                                ),
                              );
                          },
                        ),
                        ),
                      ],
                    ),
                  );
                },
              );
            }
          },
        ),
      );
  }}

class UserInfoPage extends StatelessWidget {
  const UserInfoPage({super.key});

  @override
  Widget build(BuildContext context) {
    return const Center(child: Text('Dane użytkownika'));
  }
}

class TicketsPage extends StatelessWidget {
  TicketsPage({super.key});

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
];
