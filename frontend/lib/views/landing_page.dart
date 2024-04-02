// landing_page.dart
import 'package:flutter/material.dart';
import 'package:frontend/views/login_page.dart';
import 'package:frontend/views/offers_page.dart';
import 'package:frontend/views/register_page.dart';
import 'package:frontend/widgets/date_picker_widget.dart';
import 'package:frontend/widgets/destination_input_wdget.dart';
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
          Icon( Icons.train, color: Colors.black, size: 20,),
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
          Image.network(
            'https://i.ytimg.com/vi/9Y2uVin0ywg/maxresdefault.jpg',
            fit: BoxFit.cover,
            height: double.infinity,
            width: double.infinity,
            alignment: Alignment.center,
          ),
          Center(
            child: Card(
              elevation: 8,
              color: Colors.blue[700]?.withOpacity(0.9),
              margin: const EdgeInsets.symmetric(horizontal: 300),
              child: Padding(
                padding: const EdgeInsets.symmetric(horizontal: 150),
                child: Column(
                  mainAxisSize: MainAxisSize.min,
                  children: [
                    const Text(
                      'Wybierz trasę!',
                      style: TextStyle(fontSize: 24, fontWeight: FontWeight.w600, color: Colors.white),
                    ),
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

                        ButtonWidget(onPressed: (){}, title: 'Opcje dodatkowe'),
                        ButtonWidget(onPressed: () {
                            Navigator.of(context).push(
                              MaterialPageRoute(
                                builder: (context) => ViewOffersPage(),
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
        ],
      ),
    );
  }
}
