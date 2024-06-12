import 'package:flutter/material.dart';
import 'package:firebase_core/firebase_core.dart';
import 'package:frontend/auth.dart';
import 'package:frontend/classes/auth_service.dart';
import 'package:frontend/classes/http_service.dart';
import 'package:frontend/views/auth/register_page.dart';
import 'package:frontend/views/landing_page.dart';
import 'package:provider/provider.dart';
import 'package:frontend/classes/user_provider.dart';
import 'package:frontend/utils/http_requests.dart';
import 'package:frontend/views/auth/login_page.dart';
import 'firebase_options.dart';  // Ensure you have this file with Firebase web options

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  
  await Firebase.initializeApp(
    options: DefaultFirebaseOptions.currentPlatform,
  );

  runApp(
    MultiProvider(
      providers: [
        Provider<HttpService>(create: (_) => HttpRequests()),
        Provider<AuthService>(
          create: (context) => FirebaseAuthService(context.read<HttpService>()),
        ),
        ChangeNotifierProvider(create: (_) => UserProvider()),
      ],
      child: MyApp(),
    ),
  );
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'My App',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: LandingPage(), // Change to your initial page if needed
    );
  }
}
