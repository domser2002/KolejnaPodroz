import 'dart:math';
import 'package:flutter/material.dart';
import 'package:frontend/utils/http_requests.dart';
import 'package:provider/provider.dart';
import 'package:frontend/classes/user_provider.dart';

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
  HttpRequests request = HttpRequests();

  void _getRandomImage() async {
    final Random random = Random();
    var userProvider = Provider.of<UserProvider>(context, listen: false);
    var user = userProvider.user;

    // Naliczenie punktów
    if (user != null) {
      int newPoints = user.loyaltyPoints + 1;
      await request.updateLoyaltyPoints(
        user.id,
        newPoints,
        user!.firstName,
        user!.lastName,
        user!.email,
      );

      // Aktualizacja userProvider o nowe punkty
      user.loyaltyPoints = newPoints;
      userProvider.setUser(user);

      // Zaktualizowanie stanu widoku
      setState(() {
        selectedImage = images[random.nextInt(images.length)];
      });

      // Wyświetlenie SnackBar z informacją o naliczeniu punktów
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(content: Text('Zdobyłeś jeden punkt!')),
      );
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.transparent,
      appBar: AppBar(
        leading: null,
        automaticallyImplyLeading: false,
        backgroundColor: Colors.transparent,
        title: const Center(
            child: Text('Zdobądź jeden punkt za wyświetlenie reklamy!')),
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
