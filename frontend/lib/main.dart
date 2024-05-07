import 'package:flutter/material.dart';

import 'package:frontend/views/landing_page.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'dart:ui' as ui;
import 'classes/train_offer.dart';

void main() {
  runApp(const MainApp());
}

class MainApp extends StatelessWidget {
  const MainApp({super.key});
  final host = 'http://localhost:7006';
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
