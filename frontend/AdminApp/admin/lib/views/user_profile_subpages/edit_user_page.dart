import 'package:admin/classes/admin_provider.dart';
import 'package:admin/classes/user.dart';
import 'package:flutter/material.dart';
import 'package:admin/classes/complaint.dart';
import 'package:admin/classes/user_provider.dart';
import 'package:admin/utils/http_requests.dart';
import 'package:provider/provider.dart';

class EditUserPage extends StatelessWidget {
  final MyUser user;

  EditUserPage({required this.user, Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    Size screenSize = MediaQuery.of(context).size;
    double winWidth = screenSize.width;
    double winHeight = screenSize.height;
    HttpRequests request = HttpRequests();

    return Scaffold(
      bottomNavigationBar: BottomAppBar(
          color: Colors.white,
          height: winHeight * 0.07,
          child: const Center(
              child: Stack(
            fit: StackFit.passthrough,
            children: [
              Text("©Kolejna Podróż 2024",
                  style: TextStyle(color: Color.fromARGB(255, 78, 78, 78))),
            ],
          ))),
      appBar: AppBar(
        title: const Text(''),
        leading: IconButton(
          icon: const Icon(Icons.close),
          onPressed: () => Navigator.pop(context),
        ),
      ),
      body: Stack(
        fit: StackFit.expand,
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
                        horizontal: winWidth * 0.13,
                        vertical: winHeight * 0.07),
                    child: Column(
                      mainAxisSize: MainAxisSize.min,
                      children: [
                        Text(
                          "Podgląd użytkownika o id:${user.id}",
                          style: TextStyle(
                            color: Colors.white,
                            fontSize: 24,
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                        SizedBox(height: winHeight * 0.027),
                        Text("Imię: ${user.firstName}"),
                        SizedBox(width: winWidth * 0.027),
                        Text("Nazwisko: ${user.lastName}"),
                        Text("email: ${user.email}"),
                        SizedBox(height: winHeight * 0.027),
                        Text(
                            "Preferowany rodzaj miejsca: ${user.preferedSeatType}"),
                        Text(
                            "Preferowana lokalizacja miejsca: ${user.preferedSeatLocation}"),
                        Text(
                            "data urodzenia: ${user.birthDate.day}-${user.birthDate.month}-${user.birthDate.year}"),
                        SizedBox(height: winHeight * 0.027),
                        IconButton(
                            icon: Icon(Icons.delete),
                            onPressed: () async {
                              await request.deleteUser(user.id);
                              Navigator.pop(context);
                            }),
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
