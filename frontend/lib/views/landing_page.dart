// landing_page.dart
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:frontend/cubits/search_cubit/search_cubit.dart';
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
    return Scaffold(
      bottomNavigationBar: const  BottomAppBar(
        color: Colors.white, 
        height: 50,
        child: Center(child: Stack(fit: StackFit.passthrough,children: [
          Text("©Kolejna Podróż 2024", style: TextStyle(color: Colors.black)),
          ],
        ))),
      appBar: AppBar(
        toolbarHeight: 50,
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
            child: const  Text(
              'Zaloguj się',
              style: TextStyle(color: Colors.black),
            ),
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
            child: const Text(
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
            decoration: const BoxDecoration(
              image: DecorationImage(
                image: AssetImage('lib/assets/photos/background2.jpg'), 
                fit: BoxFit.cover,
              ),
            ),
          ),
          Center(
            child: SingleChildScrollView(
              padding: const EdgeInsets.symmetric(vertical: 200, horizontal: 300),
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
                    padding: const EdgeInsets.symmetric(horizontal: 100, vertical: 50),
                    child: Column(
                      mainAxisSize: MainAxisSize.min,
                      children: [
                    const Text(
                      'Wybierz trasę!',
                      style: TextStyle(fontSize: 24, fontWeight: FontWeight.w600, color: Colors.white),
                    ),
                    const SizedBox(height: 20), 
                    InputButton(
                      icon: const Icon(Icons.output, color: Colors.black),
                      controller: departureController,
                      prefixText: 'Z',
                      backgroundColor: Colors.white,
                    ),
                    const SizedBox(height: 16),
                  InputButton(
                      icon: const Icon(Icons.input, color: Colors.black),
                      controller: destinationController,
                      prefixText: 'DO',
                      backgroundColor: Colors.white,
                    ),
                    const SizedBox(height: 16),
                  InputButton(
                      icon: const Icon(Icons.calendar_month, color: Colors.black),
                      controller: dateController,
                      prefixText: 'KIEDY',
                      backgroundColor: Colors.white,
                    ),
                    const SizedBox(height: 20),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                      children: [

                        ButtonWidget(onPressed: (){
                               Navigator.of(context).push(
                              MaterialPageRoute(
                                builder: (context) => const UserProfilePage(),
                              ),
                            );
                        }, title: 'Opcje dodatkowe'),
                        ButtonWidget(onPressed: () {
                          context.read<SearchCubit>().searchTrains(
                            departureController.text,
                            destinationController.text,
                            dateController.text,
                          );
                            Navigator.of(context).push(
                              MaterialPageRoute(
                                builder: (context) => const ViewOffersPage(),
                              ),
                            );
                        }, title: 'Wyszukaj'),
                      ],
                    ),
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
}
