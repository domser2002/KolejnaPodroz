import 'package:flutter/material.dart';


class UserProfilePage extends StatefulWidget {
  const UserProfilePage({super.key});

  @override
  // ignore: library_private_types_in_public_api
  _UserProfilePageState createState() => _UserProfilePageState();
}

class _UserProfilePageState extends State<UserProfilePage> with TickerProviderStateMixin {
  late TabController _tabController;

  @override
  void initState() {
    super.initState();
    _tabController = TabController(length: 4, vsync: this);
  }

  @override
  void dispose() {
    _tabController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
            bottomNavigationBar: const  BottomAppBar(
        color: Colors.white, 
        height: 50,
        child: Center(child: Stack(fit: StackFit.passthrough,children: [
          Text("©Kolejna Podróż 2024", style: TextStyle(color: Colors.black)),
          ],
        ))),
      appBar: AppBar(
        title: const Center(child: Text('Moje konto')),
        backgroundColor: Colors.transparent,
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
              padding: const EdgeInsets.symmetric(horizontal: 300, vertical: 100),
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
                  shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(40)),
                  child: Row(
                    children: [
                      // Pionowy pasek z zakładkami
                      Container(
                        width: 200,
                        color: Colors.grey[400], // Tło dla zakładek Tab
                        child: const Column(
                          children:  [
                            Tab(text: 'Dane użytkownika', icon: Icon(Icons.person,color: Colors.white,)),
                            Tab(text: 'Bilety', icon: Icon(Icons.airplane_ticket, color: Colors.white,)),
                            Tab(text: 'Statystyki', icon: Icon(Icons.bar_chart, color: Colors.white,)),
                            Tab(text: 'Osiągnięcia', icon: Icon(Icons.star, color: Colors.white,)),
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
                            color: Colors.grey[400], // Szare tło dla TabBarView
                            borderRadius: const  BorderRadius.only(
                              topRight: Radius.circular(20),
                              bottomRight: Radius.circular(40),
                            ),
                          ),
                          child: TabBarView(
                            controller: _tabController,
                            children: const [
                              UserInfoPage(),
                              TicketsPage(),
                              StatisticsPage(),
                              AchievementsPage(),
                            ],
                          ),
                        ),                   ),
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

class UserInfoPage extends StatelessWidget {
  const UserInfoPage({super.key});

  @override
  Widget build(BuildContext context) {
    return const Center(child: Text('Dane użytkownika'));
  }
}

class TicketsPage extends StatelessWidget {
  const TicketsPage({super.key});

  @override
  Widget build(BuildContext context) {
    return const Center(child: Text('Bilety'));
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
