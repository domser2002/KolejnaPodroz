import 'package:flutter/material.dart';
import 'package:frontend/views/landing_page.dart';

void main() {
  runApp(const MainApp());
}

class MainApp extends StatelessWidget {
  const MainApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Kolejna Podróż',
      theme: ThemeData(
        primarySwatch: Colors.blue, 
      ),
      home: LandingPage(),
    );
  }
}
