import 'package:flutter/material.dart';
import 'package:frontend/views/landing_page.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'offers_cubit/train_offers_cubit.dart';

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
      home: BlocProvider(
        create: (context) => TrainOffersCubit(),
        child:   LandingPage(),
    ));
  }
}