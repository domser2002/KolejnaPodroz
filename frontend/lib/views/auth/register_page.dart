import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/material.dart';
import 'package:frontend/utils/http_requests.dart';
import 'package:frontend/widgets/input_button_widget.dart';
import 'package:frontend/widgets/socialmedia_button.dart';

class RegistrationPage extends StatelessWidget {
  final TextEditingController emailController = TextEditingController();
  final TextEditingController passwordController = TextEditingController();
  final TextEditingController repeatPasswordController =
      TextEditingController();
    HttpRequests request = HttpRequests();
  RegistrationPage({Key? key}) : super(key: key);
    Future<void> signUpWithEmailAndPassword(BuildContext context) async {
    if (passwordController.text == repeatPasswordController.text) {
      try {
        await FirebaseAuth.instance.createUserWithEmailAndPassword(
          email: emailController.text,
          password: passwordController.text,
        );
        Navigator.of(context).popUntil((route) => route.isFirst);
      } on FirebaseAuthException catch (e) {
        print(e.message);
      }
    } else {
      print("Email exists");
    }
  }
  @override
  Widget build(BuildContext context) {
    Size screenSize = MediaQuery.of(context).size;
    double win_width = screenSize.width;
    double win_height = screenSize.height;

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
        title: Text(''),
        leading: IconButton(
          icon: Icon(Icons.close),
          onPressed: () => Navigator.pop(context),
        ),
      ),
      body: Stack(
        fit: StackFit.expand,
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
                          'Zarejestruj się',
                          style: TextStyle(
                            color: Colors.white,
                            fontSize: 24,
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                        SizedBox(height: win_height * 0.027),
                        InputButton(
                          controller: emailController,
                          hintText: 'E-mail',
                          icon: Icon(Icons.email),
                          obscureText: false,
                          backgroundColor: Colors.white,
                        ),
                        SizedBox(height: win_height * 0.022),
                        InputButton(
                          controller: passwordController,
                          hintText: 'Password',
                          icon: Icon(Icons.lock),
                          obscureText: true,
                          backgroundColor: Colors.white,
                        ),
                        SizedBox(height: win_height * 0.022),
                        InputButton(
                          controller: repeatPasswordController,
                          hintText: 'Repeat password',
                          icon: Icon(Icons.lock),
                          obscureText: true,
                          backgroundColor: Colors.white,
                        ),
                        SizedBox(height: win_height * 0.027),
                        ElevatedButton(
                          onPressed: () async {
                            await signUpWithEmailAndPassword(context);
                            
                          },
                          style: ElevatedButton.styleFrom(
                            foregroundColor: Colors.white,
                            backgroundColor: Colors.orange,
                          ),
                          child: Text('Zarejestruj się'),
                        ),
                        TextButton(
                          child: Text(
                            'Masz już konto? Zaloguj się',
                            style: TextStyle(color: Colors.white),
                          ),
                          onPressed: () {
                            // Handle navigate to login action
                          },
                        ),
                        Divider(color: Colors.white),
                        Text('Lub', style: TextStyle(color: Colors.white)),
                        SizedBox(height: win_height * 0.022),
                        SocialButton(
                          text: 'Zarejestruj się przez Apple',
                          logo: 'lib/assets/photos/apple_white.png',
                          color: Colors.black,
                          textColor: Colors.white,
                          onPressed: () {
                            // Handle register with Apple action
                          },
                        ),
                        SizedBox(height: win_height * 0.022),
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
