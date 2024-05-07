// landing_page.dart
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:frontend/classes/train_offer.dart';

import 'package:frontend/utils/http_requests.dart';
import 'package:frontend/views/auth/login_page.dart';
import 'package:frontend/views/offers_page.dart';
import 'package:frontend/views/auth/register_page.dart';
import 'package:frontend/views/user_profile_page.dart';
import 'package:frontend/widgets/button_widget.dart';

import '../widgets/input_button_widget.dart';

class LandingPage extends StatelessWidget {
  final TextEditingController departureController = TextEditingController();
  final TextEditingController destinationController = TextEditingController();
  final TextEditingController dateController = TextEditingController();

  LandingPage({super.key});

  @override
  Widget build(BuildContext context) {
    Size screenSize = MediaQuery.of(context).size;
    double win_width = screenSize.width;
    double win_height = screenSize.height;

    print(win_width);
    print(win_height);

    return Scaffold(
      bottomNavigationBar: BottomAppBar(
          color: Colors.white,
          height: win_height * 0.07,
          child: Center(
              child: Stack(
            fit: StackFit.passthrough,
            children: [
              Text("©Kolejna Podróż 2024",
                  style: TextStyle(color: Colors.black)),
            ],
          ))),
      appBar: AppBar(
        toolbarHeight: win_height * 0.07,
        backgroundColor: Colors.white,
        elevation: 0,
        actions: [
          TextButton(
            onPressed: () {
              Navigator.of(context).push(
                MaterialPageRoute(
                  builder: (context) => LoginPage(),
                ),
              );
            },
            child: Text(
              'Zaloguj się',
              style: TextStyle(color: Colors.black),
            ),
          ),
          VerticalDivider(
              color: Colors.black,
              thickness: 1,
              width: win_width * 0.013,
              indent: win_width * 0.011,
              endIndent: win_width * 0.01),
          TextButton(
            onPressed: () {
              Navigator.of(context).push(
                MaterialPageRoute(
                  builder: (context) => RegistrationPage(),
                ),
              );
            },
            child: Text(
              'Zarejestruj się',
              style: TextStyle(color: Colors.black),
            ),
          ),
        ],
      ),
      extendBodyBehindAppBar: true,
      body: Stack(
        children: [
          Container(
            decoration: BoxDecoration(
              image: DecorationImage(
                image: AssetImage('lib/assets/photos/background2.jpg'),
                fit: BoxFit.cover,
              ),
            ),
          ),
          Center(
            child: SingleChildScrollView(
              padding: EdgeInsets.symmetric(
                  vertical: win_height * 0.27, horizontal: win_width * 0.2),
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
                        horizontal: win_width * 0.07,
                        vertical: win_height * 0.07),
                    child: Column(
                      mainAxisSize: MainAxisSize.min,
                      children: [
                        Text(
                          'Wybierz trasę!',
                          style: TextStyle(
                              fontSize: 24,
                              fontWeight: FontWeight.w600,
                              color: Colors.white),
                        ),
                        SizedBox(height: win_height * 0.027),
                        InputButton(
                          icon: Icon(Icons.output, color: Colors.black),
                          controller: departureController,
                          prefixText: 'Z',
                          backgroundColor: Colors.white,
                        ),
                        SizedBox(height: win_height * 0.022),
                        InputButton(
                          icon: Icon(Icons.input, color: Colors.black),
                          controller: destinationController,
                          prefixText: 'DO',
                          backgroundColor: Colors.white,
                        ),
                        SizedBox(height: win_height * 0.022),
                        InputButton(
                          icon: Icon(Icons.calendar_month, color: Colors.black),
                          controller: dateController,
                          prefixText: 'KIEDY',
                          backgroundColor: Colors.white,
                        ),
                        SizedBox(height: win_height * 0.027),
                        _buildButtonsRowOrColumn(win_width, context)
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
    http_requests request = http_requests();

    if (winWidth > 600) {
      return Row(
        mainAxisAlignment: MainAxisAlignment.spaceEvenly,
        children: [
          ButtonWidget(
            onPressed: () {
              Navigator.of(context).push(
                MaterialPageRoute(
                  builder: (context) => UserProfilePage(),
                ),
              );
            },
            title: 'Opcje dodatkowe',
          ),
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
    } else {
      return Column(
        mainAxisAlignment: MainAxisAlignment.spaceEvenly,
        children: [
          ButtonWidget(
            onPressed: () {
              Navigator.of(context).push(
                MaterialPageRoute(
                  builder: (context) => UserProfilePage(),
                ),
              );
            },
            title: 'Opcje dodatkowe',
          ),
          SizedBox(height: 5),
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
