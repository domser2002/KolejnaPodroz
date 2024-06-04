import 'dart:math';
import 'package:flutter/material.dart';

class SuperPointsPage extends StatefulWidget {
  SuperPointsPage({super.key});

  @override
  _SuperPointsPageState createState() => _SuperPointsPageState();
}

class _SuperPointsPageState extends State<SuperPointsPage> {
  final List<String> images = [
    'lib/assets/photos/reklama_1.png',
    'lib/assets/photos/lidl-czy-biedronka-reklamy.jpg',
  ];
  String? selectedImage;

  void _getRandomImage() {
    final Random random = Random();
    setState(() {
      selectedImage = images[random.nextInt(images.length)];
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.transparent,
      appBar: AppBar(
        leading: null,
        automaticallyImplyLeading: false,
        backgroundColor: Colors.transparent,
        title: const Center(child: Text('Zdobądź jeden punkt za wyświetlenie reklamy!')),
      ),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            if (selectedImage == null)
              ElevatedButton(
                onPressed: _getRandomImage,
                style: ElevatedButton.styleFrom(
                  backgroundColor: Colors.orange,
                  foregroundColor: Colors.white,
                  shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(18.0),
                  ),
                ),
                child: const Text('Zdobądź punkty'),
              ),
            if (selectedImage != null)
              Expanded(
                child: Padding(
                  padding: const EdgeInsets.all(8.0),
                  child: Image.asset(
                    selectedImage!,
                    fit: BoxFit.contain,
                    width: double.infinity,
                    height: double.infinity,
                  ),
                ),
              ),
          ],
        ),
      ),
    );
  }
}
