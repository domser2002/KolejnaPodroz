import 'package:flutter/material.dart';
import 'package:frontend/classes/user_provider.dart';
import 'package:frontend/views/user_profile_subpages/complaints_page.dart';
import 'package:frontend/views/user_profile_subpages/tickets_page.dart';
import 'package:frontend/views/user_profile_subpages/user_info_page.dart';
import 'package:provider/provider.dart';

class UserProfilePage extends StatefulWidget {
  UserProfilePage({super.key});

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
    UserProvider userProvider = Provider.of<UserProvider>(context);
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
        title: const Stack(alignment: AlignmentDirectional.centerEnd, children: [
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
                     const  Text("Moje konto",
                          style: TextStyle(
                              fontSize: 24,
                              fontWeight: FontWeight.w600,
                              color: Colors.white)),
                      SizedBox(height: win_height * 0.05),
                      Container(
                        decoration: BoxDecoration(
                          borderRadius: const BorderRadius.all(Radius.circular(10)),
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
                              const EdgeInsets.symmetric(horizontal: 2, vertical: 2),
                          dividerHeight: 0,
                          controller: _tabController,
                          indicatorColor: Colors.orange[700],
                          labelColor: Colors.orange[700],
                          tabs: [
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
                                text: 'Osiągnięcia',
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
                          height: win_height * 0.5,
                          decoration: BoxDecoration(
                            borderRadius: const BorderRadius.all(Radius.circular(15)),
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


class StatisticsPage extends StatelessWidget {
  StatisticsPage({super.key});

  @override
  Widget build(BuildContext context) {
    return Center(child: Text('Statystyki'));
  }
}

class AchievementsPage extends StatelessWidget {
  AchievementsPage({super.key});

  @override
  Widget build(BuildContext context) {
    return Center(child: Text('Osiągnięcia'));
  }
}


