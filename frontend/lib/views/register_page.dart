import 'package:flutter/material.dart';
import 'package:frontend/widgets/input_button_widget.dart';
import 'package:frontend/widgets/socialmedia_button.dart';

class RegistrationPage extends StatelessWidget {
  final TextEditingController emailController = TextEditingController();
  final TextEditingController passwordController = TextEditingController();
  final TextEditingController repeatPasswordController = TextEditingController();

  RegistrationPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
            bottomNavigationBar: const  BottomAppBar(
        color: Colors.white, 
        height: 50,
        child: Center(child:  Stack(fit: StackFit.passthrough,children: [
          Text("©Kolejna Podróż 2024", style: TextStyle(color: Colors.black)),
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
                    padding: const EdgeInsets.symmetric(horizontal: 200, vertical: 50),
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
                        const SizedBox(height: 20),
                        InputButton(
                          controller: emailController,
                          hintText: 'E-mail',
                          icon: const Icon(Icons.email),
                          obscureText: false,
                          backgroundColor: Colors.white,
                        ),
                        const SizedBox(height: 10),
                        InputButton(
                          controller: passwordController,
                          hintText: 'Password',
                          icon: const Icon(Icons.lock),
                          obscureText: true,
                          backgroundColor: Colors.white,
                        ),
                        const SizedBox(height: 10),
                        InputButton(
                          controller: repeatPasswordController,
                          hintText: 'Repeat password',
                          icon: const Icon(Icons.lock),
                          obscureText: true,
                          backgroundColor: Colors.white,
                        ),
                        const SizedBox(height: 20),
                        ElevatedButton(
                          child: const Text('Zarejestruj się'),
                          onPressed: () {
                            // Handle registration action
                          },
                          style: ElevatedButton.styleFrom(
                            foregroundColor: Colors.white,
                            backgroundColor: Colors.orange,
                          ),
                        ),
                        TextButton(
                          child: const Text(
                            'Masz już konto? Zaloguj się',
                            style: TextStyle(color: Colors.white),
                          ),
                          onPressed: () {
                            // Handle navigate to login action
                          },
                        ),
                        const Divider(color: Colors.white),
                        const Text('Lub', style: TextStyle(color: Colors.white)),
                        const SizedBox(height: 10),
                        SocialButton(
                          text: 'Zarejestruj się przez Apple',
                          logo: 'lib/assets/photos/apple_white.png',
                          color: Colors.black,
                          textColor: Colors.white,
                          onPressed: () {
                            // Handle register with Apple action
                          },
                        ),
                        const SizedBox(height: 10),
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
