import 'package:flutter/material.dart';
import 'package:frontend/cubits/achievements_cubit/achievements_cubit.dart';
import 'package:frontend/cubits/search_cubit/search_cubit.dart';
import 'package:frontend/views/landing_page.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'dart:ui' as ui;
import 'classes/train_offer.dart';
import 'offers_cubit/train_offers_cubit.dart';

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
        home: MultiBlocProvider(
          providers: [
            BlocProvider<TrainOffersCubit>(
                create: (context) => TrainOffersCubit()),
            BlocProvider<SearchCubit>(create: (context) => SearchCubit()),
          ],
          child: LandingPage(),
        ));
  }
}
