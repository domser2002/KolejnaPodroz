import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/material.dart';
import 'package:frontend/classes/train_offer.dart';
import 'package:frontend/utils/http_requests.dart';
import 'package:frontend/views/auth/login_page.dart';
import 'package:frontend/views/auth/register_page.dart';
import 'package:frontend/views/offers/buy_ticket.dart';
import 'package:frontend/views/user_profile_page.dart';

class ViewOffersPage extends StatelessWidget {
  final List<TrainOffer> offers;
  ViewOffersPage({super.key, required this.offers});

  @override
  Widget build(BuildContext context) {
    final PageController controller = PageController(viewportFraction: 0.4);

    return Scaffold(
        bottomNavigationBar: const BottomAppBar(
            color: Colors.white,
            height: 50,
            child: Center(
                child: Stack(
              fit: StackFit.passthrough,
              children: [
                Text("©Kolejna Podróż 2024",
                    style: TextStyle(color: Colors.black)),
              ],
            ))),
        appBar: AppBar(
          title: const Text('Wybierz pociąg!'),
          actions: [
            StreamBuilder<User?>(
              stream: FirebaseAuth.instance.authStateChanges(),
              builder: (context, snapshot) {
                if (snapshot.hasData) {
                  // Użytkownik jest zalogowany
                  return Row(
                    children: [
                      IconButton(
                        icon: const Icon(Icons.person, color: Colors.black),
                        onPressed: () {
                          Navigator.of(context).push(
                            MaterialPageRoute(
                              builder: (context) => UserProfilePage(),
                            ),
                          );
                        },
                      ),
                      IconButton(
                        icon: const Icon(Icons.exit_to_app, color: Colors.red),
                        onPressed: () {
                          FirebaseAuth.instance.signOut();
                        },
                      ),
                    ],
                  );
                } else {
                  // Użytkownik jest wylogowany
                  return Row(
                    children: [
                      TextButton(
                        onPressed: () {
                          Navigator.of(context).push(
                            MaterialPageRoute(
                              builder: (context) => LoginPage(),
                            ),
                          );
                        },
                        child: const Text('Zaloguj się',
                            style: TextStyle(color: Colors.black)),
                      ),
                      const VerticalDivider(
                          color: Colors.black,
                          thickness: 1,
                          width: 20,
                          indent: 18,
                          endIndent: 16),
                      TextButton(
                        onPressed: () {
                          Navigator.of(context).push(
                            MaterialPageRoute(
                              builder: (context) => RegistrationPage(),
                            ),
                          );
                        },
                        child: const Text('Zarejestruj się',
                            style: TextStyle(color: Colors.black)),
                      ),
                    ],
                  );
                }
              },
            ),
          ],
        ),
        body: Stack(
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
              child: Padding(
                padding: const EdgeInsets.symmetric(vertical: 24.0),
                child: AspectRatio(
                  aspectRatio: 2.0,
                  child: Cards(controller: controller, offers: offers),
                ),
              ),
            ),
          ],
        ));
  }
}

class Cards extends StatelessWidget {
  final PageController controller;
  final List<TrainOffer> offers;
  Cards({
    super.key,
    required this.controller,
    required this.offers,
  });

  @override
  Widget build(BuildContext context) {
    if (offers.isNotEmpty) {
      return PageView.builder(
        controller: controller,
        itemCount: offers.length,
        itemBuilder: (context, index) {
          return AnimatedBuilder(
            animation: controller,
            builder: (context, child) {
              double value = 1.0;
              if (controller.position.haveDimensions) {
                value = controller.page! - index;
                value = (1 - (value.abs() * .3)).clamp(0.5, 1.0);
              }
              return Center(
                child: SizedBox(
                  height: Curves.easeOut.transform(value) * 500,
                  width: Curves.easeOut.transform(value) * 350,
                  child: child,
                ),
              );
            },
            child: TrainOfferCard(
              trainOffer: offers.elementAt(index),
              elevation: index == 2 ? 8 : 4, // Większy cień dla karty w centrum
              isLarge: index == 2,
              onPressed: () {
                Navigator.of(context).push(
                  MaterialPageRoute(
                    builder: (context) => BuyTicketPage(
                      trainOffer: offers.elementAt(index),
                    ),
                  ),
                );
              },
            ),
          );
        },
      );
    } else {
      return Center(
        child: SizedBox(
          width: 200,
          height: 100,
          child: Container(
            decoration: const BoxDecoration(color: Colors.green),
            child: const Center(child: Text("Nie ma takich przejazdów")),
          ),
        ),
      );
    }
  }
}

class TrainOfferCard extends StatelessWidget {
  final bool isLarge;
  final double elevation;
  final TrainOffer trainOffer;
  final VoidCallback onPressed;
  TrainOfferCard(
      {Key? key,
      this.isLarge = false,
      this.elevation = 4,
      required this.trainOffer,
      required this.onPressed})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    int dmin = trainOffer.departure.first.minute;
    String dMin = dmin < 10
        ? "0${trainOffer.departure.first.minute}"
        : trainOffer.departure.first.minute.toString();
    int amin = trainOffer.arrival.last.minute;
    String aMin = amin < 10
        ? "0${trainOffer.arrival.last.minute}"
        : trainOffer.arrival.last.minute.toString();

    String departureTime = '${trainOffer.departure.first.hour}:$dMin';
    String departureStation = trainOffer.stations.first;
    String arrivalTime = '${trainOffer.arrival.last.hour}:$aMin';
    String arrivalStation = trainOffer.stations.last;
    String time =
        "${trainOffer.arrival.last.difference(trainOffer.departure.first).inMinutes}min";

    return Card(
      color: Colors.transparent,
      elevation: elevation,
      margin: const EdgeInsets.symmetric(horizontal: 10, vertical: 20),
      child: Container(
        padding: const EdgeInsets.all(16),
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
        child: Column(
          children: <Widget>[
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: <Widget>[
                Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: <Widget>[
                    const Text('ODJAZD', style: TextStyle(color: Colors.white)),
                    Text(departureTime,
                        style: const TextStyle(fontSize: 26, color: Colors.white)),
                    Text(
                      departureStation,
                      style: const TextStyle(color: Colors.white),
                    ),
                  ],
                ),
                Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: <Widget>[
                    const Text('PRZYJAZD', style: TextStyle(color: Colors.white)),
                    Text(arrivalTime,
                        style: const TextStyle(fontSize: 26, color: Colors.white)),
                    Text(arrivalStation,
                        style: const TextStyle(color: Colors.white)),
                  ],
                ),
              ],
            ),
            const SizedBox(height: 8),
            Row(
              mainAxisAlignment: MainAxisAlignment.start,
              children: <Widget>[
                const Icon(Icons.access_time, color: Colors.white),
                const SizedBox(width: 8),
                Text(time, style: const TextStyle(fontSize: 22, color: Colors.white)),
              ],
            ),
            const SizedBox(height: 8),
            const Divider(),
            const Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: <Widget>[
                Icon(Icons.train, color: Colors.white),
                Text('   IC81170',
                    style: TextStyle(
                        fontSize: 18,
                        fontWeight: FontWeight.w900,
                        color: Colors.white)),
              ],
            ),
            const Text('Klasa 1: od 90,00 zł',
                style: TextStyle(fontSize: 25, color: Colors.white)),
            const Text('Klasa 2: od 58,65 zł',
                style: TextStyle(fontSize: 25, color: Colors.white)),
            const SizedBox(height: 50),
            ElevatedButton(
              onPressed: onPressed,
              style: ElevatedButton.styleFrom(
                backgroundColor: Colors.orange, // Background color
                foregroundColor: Colors.white, // Text Color
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(18.0),
                ),
              ),
              child: const Text('Wybierz'),
            ),
          ],
        ),
      ),
    );
  }
}
