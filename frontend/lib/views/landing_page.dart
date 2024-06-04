// landing_page.dart
import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/material.dart';
import 'package:frontend/classes/user_provider.dart';

import 'package:frontend/utils/http_requests.dart';
import 'package:frontend/views/auth/login_page.dart';
import 'package:frontend/views/offers/offers_page.dart';
import 'package:frontend/views/auth/register_page.dart';
import 'package:frontend/views/user_profile_page.dart';
import 'package:frontend/widgets/button_widget.dart';
import 'package:frontend/widgets/date_picker_widget.dart';
import 'package:provider/provider.dart';

import '../widgets/input_button_widget.dart';

class LandingPage extends StatelessWidget {
  final TextEditingController departureController = TextEditingController();
  final TextEditingController destinationController = TextEditingController();
  final TextEditingController dateController = TextEditingController();
  final request = HttpRequests();
  LandingPage({super.key});

  @override
  Widget build(BuildContext context) {
    Size screenSize = MediaQuery.of(context).size;
    double winWidth = screenSize.width;
    double winHeight = screenSize.height;
    UserProvider userProvider = Provider.of<UserProvider>(context);


    return Scaffold(
      bottomNavigationBar: BottomAppBar(
          color: Colors.white,
          height: winHeight * 0.07,
          child: const Center(
              child: Stack(
            fit: StackFit.passthrough,
            children: [
              Text("©Kolejna Podróż 2024",
                  style: TextStyle(color: Colors.black)),
            ],
          ))),
      appBar: AppBar(
        backgroundColor: Colors.white,
        elevation: 0,
        actions: [
          StreamBuilder<User?>(
            stream: FirebaseAuth.instance.authStateChanges(),
            builder: (context, snapshot) {
              if (snapshot.hasData) {
        // Użytkownik jest zalogowany
        return Row(
          children: [
            if (userProvider.user != null)
          Padding(
            padding: const EdgeInsets.only(right: 8.0),
            child: Text(
              'Cześć, ${userProvider.user!.firstName}',
              style: const TextStyle(fontSize: 16, fontWeight: FontWeight.bold),
            ),
          ),
          //Punkty
            const Text(
              '0',
              style: TextStyle(fontSize: 16, fontWeight: FontWeight.bold),
            ),
            IconButton(
              icon: const Icon(Icons.person, color: Colors.black),
              onPressed: () {
                Navigator.of(context).push(
                  MaterialPageRoute(
                    builder: (context) => UserProfilePage(),
                  ),
                );
              },
            ),
            IconButton(
              icon: const Icon(Icons.exit_to_app, color: Colors.red),
              onPressed: () {
                FirebaseAuth.instance.signOut();
              },
            ),
          ],
        );
      } else {
                // Użytkownik jest wylogowany
                return Row(
                  children: [
                    TextButton(
                      onPressed: () {
                        Navigator.of(context).push(
                          MaterialPageRoute(
                            builder: (context) => LoginPage(),
                          ),
                        );
                      },
                      child: const Text('Zaloguj się', style: TextStyle(color: Colors.black)),
                    ),
                    const VerticalDivider(color: Colors.black, thickness: 1, width: 20, indent: 18, endIndent: 16),
                    TextButton(
                      onPressed: () {
                        Navigator.of(context).push(
                          MaterialPageRoute(
                            builder: (context) => RegistrationPage(),
                          ),
                        );
                      },
                      child: const Text('Zarejestruj się', style: TextStyle(color: Colors.black)),
                    ),
                  ],
                );
              }
            },
          ),
        ],
      ),
      extendBodyBehindAppBar: true,
      body: Stack(
        children: [
          Container(
            decoration: const BoxDecoration(
              image: DecorationImage(
                image: AssetImage('lib/assets/photos/background2.jpg'),
                fit: BoxFit.cover,
              ),
            ),
          ),
          Center(
            child: SingleChildScrollView(
              padding: EdgeInsets.symmetric(
                  vertical: winHeight * 0.27, horizontal: winWidth * 0.2),
              child: Container(
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
                    borderRadius: BorderRadius.circular(40),
                  ),
                  child: Padding(
                    padding: EdgeInsets.symmetric(
                        horizontal: winWidth * 0.07,
                        vertical: winHeight * 0.07),
                    child: Column(
                      mainAxisSize: MainAxisSize.min,
                      children: [
                        const Text(
                          'Wybierz trasę!',
                          style: TextStyle(
                              fontSize: 24,
                              fontWeight: FontWeight.w600,
                              color: Colors.white),
                        ),
                        SizedBox(height: winHeight * 0.027),
                        InputButton(
                          icon: const Icon(Icons.output, color: Colors.black),
                          controller: departureController,
                          prefixText: 'Z',
                          backgroundColor: Colors.white,
                        ),
                        SizedBox(height: winHeight * 0.022),
                        InputButton(
                          icon: const Icon(Icons.input, color: Colors.black),
                          controller: destinationController,
                          prefixText: 'DO',
                          backgroundColor: Colors.white,
                        ),
                        SizedBox(height: winHeight * 0.022),
                        DatePickerWidget(controller: dateController),
                        SizedBox(height: winHeight * 0.027),
                        _buildButtonsRowOrColumn(winWidth, context)
                      ],
                    ),
                  ),
                ),
              ),
            ),
          ),
        ],
      ),
    );
  }

  Widget _buildButtonsRowOrColumn(double winWidth, BuildContext context) {
    if (winWidth > 600) {
      return Row(
        mainAxisAlignment: MainAxisAlignment.spaceEvenly,
        children: [
          ButtonWidget(
            onPressed: () async {
              var offers = await request.searchTrains(
                departureController.text,
                destinationController.text,
                dateController.text,
              );
              if (offers != 0) {
                Navigator.of(context).push(
                  MaterialPageRoute(
                    builder: (context) => ViewOffersPage(offers: offers),
                  ),
                );
              } else {}
            },
            title: 'Wyszukaj',
          ),
        ],
      );
    } else {
      return Column(
        mainAxisAlignment: MainAxisAlignment.spaceEvenly,
        children: [
          const SizedBox(height: 5),
          ButtonWidget(
            onPressed: () async {
              var offers = await request.searchTrains(
                departureController.text,
                destinationController.text,
                dateController.text,
              );

              Navigator.of(context).push(
                MaterialPageRoute(
                builder: (context) => ViewOffersPage(offers: offers),
               ),
              );
            },
            title: 'Wyszukaj',
          ),
        ],
      );
    }
  }
}
