import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/material.dart';
import 'package:frontend/classes/auth_service.dart';
import 'package:frontend/classes/http_service.dart';
import 'package:frontend/classes/user.dart';
import 'package:provider/provider.dart';
import 'package:frontend/classes/user_provider.dart';
import 'package:frontend/widgets/input_button_widget.dart';
import 'package:frontend/widgets/socialmedia_button.dart';
import 'package:frontend/views/auth/login_page.dart';

class RegistrationPage extends StatelessWidget {
  final TextEditingController emailController = TextEditingController();
  final TextEditingController passwordController = TextEditingController();
  final TextEditingController repeatPasswordController = TextEditingController();
  final TextEditingController firstNameController = TextEditingController();
  final TextEditingController lastNameController = TextEditingController();

  RegistrationPage({Key? key}) : super(key: key);

  Future<void>? signUpWithEmailAndPassword(BuildContext context) async {
    final authService = Provider.of<AuthService>(context, listen: false);
    final httpService = Provider.of<HttpService>(context, listen: false);

    if (passwordController.text == repeatPasswordController.text) {
      try {
        await authService.registerWithEmailAndPassword(
          emailController.text,
          passwordController.text,
        );

        var userData = {
          'firstName': firstNameController.text,
          'lastName': lastNameController.text,
          'email': emailController.text,
          'firebaseID': authService.currentUser?.uid ?? '',
        };

        var createdUser = await httpService.createUser(userData);

        if (createdUser != null) {
          MyUser user = MyUser.fromJson(createdUser);

          // Save user details to the provider
          Provider.of<UserProvider>(context, listen: false).setUser(user);

          Navigator.of(context).popUntil((route) => route.isFirst);
        }

        await httpService.authoriseUser(authService.currentUser?.uid ?? '');

      } on FirebaseAuthException catch (e) {
        print(e.message);
      }
    } else {
      print("Passwords do not match");
    }
  }

  @override
  Widget build(BuildContext context) {
    Size screenSize = MediaQuery.of(context).size;
    double winWidth = screenSize.width;
    double winHeight = screenSize.height;

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
          ),
        ),
      ),
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
                vertical: winHeight * 0.27,
                horizontal: winWidth * 0.2
              ),
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
                      vertical: winHeight * 0.07
                    ),
                    child: Column(
                      mainAxisSize: MainAxisSize.min,
                      children: [
                        const Text(
                          'Zarejestruj się',
                          style: TextStyle(
                            color: Colors.white,
                            fontSize: 24,
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                        SizedBox(height: winHeight * 0.027),
                        Row(
                          children: [
                            Expanded(
                              child: InputButton(
                                controller: firstNameController,
                                hintText: 'Imię',
                                icon: const Icon(Icons.person),
                                obscureText: false,
                                backgroundColor: Colors.white,
                              ),
                            ),
                            SizedBox(width: winWidth * 0.02),
                            Expanded(
                              child: InputButton(
                                controller: lastNameController,
                                hintText: 'Nazwisko',
                                icon: const Icon(Icons.person),
                                obscureText: false,
                                backgroundColor: Colors.white,
                              ),
                            ),
                          ],
                        ),
                        SizedBox(height: winHeight * 0.022),
                        InputButton(
                          controller: emailController,
                          hintText: 'E-mail',
                          icon: const Icon(Icons.email),
                          obscureText: false,
                          backgroundColor: Colors.white,
                        ),
                        SizedBox(height: winHeight * 0.022),
                        InputButton(
                          controller: passwordController,
                          hintText: 'Hasło',
                          icon: const Icon(Icons.lock),
                          obscureText: true,
                          backgroundColor: Colors.white,
                        ),
                        SizedBox(height: winHeight * 0.022),
                        InputButton(
                          controller: repeatPasswordController,
                          hintText: 'Powtórz hasło',
                          icon: const Icon(Icons.lock),
                          obscureText: true,
                          backgroundColor: Colors.white,
                        ),
                        SizedBox(height: winHeight * 0.027),
                        ElevatedButton(
                           key: const Key('signUpButton'),
                          onPressed: () async {
                            await signUpWithEmailAndPassword(context);
                          },
                          style: ElevatedButton.styleFrom(
                            foregroundColor: Colors.white,
                            backgroundColor: Colors.orange,
                          ),
                          child: const Text('Zarejestruj się'),
                        ),
                        TextButton(
                          child: const Text(
                            'Masz już konto? Zaloguj się',
                            style: TextStyle(color: Colors.white),
                          ),
                          onPressed: () {
                            Navigator.push(
                              context,
                              MaterialPageRoute(
                                builder: (context) => LoginPage(),
                              ),
                            );
                          },
                        ),
                        const Divider(color: Colors.white),
                        const Text('Lub', style: TextStyle(color: Colors.white)),
                        SizedBox(height: winHeight * 0.022),
                        SocialButton(
                          text: 'Zarejestruj się przez Apple',
                          logo: 'lib/assets/photos/apple_white.png',
                          color: Colors.black,
                          textColor: Colors.white,
                          onPressed: () {
                            // Handle register with Apple action
                          },
                        ),
                        SizedBox(height: winHeight * 0.022),
                        SocialButton(
                          text: 'Zarejestruj się przez Google',
                          logo: 'lib/assets/photos/google.png',
                          color: Colors.white,
                          textColor: Colors.black,
                          onPressed: () {
                            // Handle register with Google action
                          },
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
