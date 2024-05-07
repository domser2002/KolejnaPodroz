import 'package:flutter/material.dart';
import 'package:frontend/classes/train_offer.dart';
import 'package:frontend/utils/http_requests.dart';
import 'package:frontend/views/auth/login_page.dart';
import 'package:frontend/views/auth/register_page.dart';

class ViewOffersPage extends StatelessWidget {
  var offers;
  ViewOffersPage({super.key, required this.offers});

  @override
  Widget build(BuildContext context) {
    final PageController controller = PageController(viewportFraction: 0.4);

    return Scaffold(
        bottomNavigationBar: BottomAppBar(
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
          title: Text('Wybierz pociąg!'),
          actions: <Widget>[
            TextButton(
              onPressed: () {
                Navigator.of(context).push(
                  MaterialPageRoute(
                    builder: (context) => LoginPage(),
                  ),
                );
              },
              child: Text(
                'Zaloguj się',
                style: TextStyle(color: Colors.black),
              ),
            ),
            VerticalDivider(
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
              child: Text(
                'Zarejestruj się',
                style: TextStyle(color: Colors.black),
              ),
            ),
          ],
        ),
        body: Stack(
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
              child: Padding(
                padding: EdgeInsets.symmetric(vertical: 24.0),
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
  Cards({
    super.key,
    required this.controller,
    required this.offers,
  });

  PageController controller;
  var offers;

  @override
  Widget build(BuildContext context) {
    if (offers != null) {
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
            ),
          );
        },
      );
    } else {
      return Center(
        child: SizedBox(
          child: Container(
            child: Center(child: Text("Nie ma takich przejazdów")),
            decoration: BoxDecoration(color: Colors.green),
          ),
          width: 200,
          height: 100,
        ),
      );
    }
  }
}

class TrainOfferCard extends StatelessWidget {
  final bool isLarge;
  final double elevation;
  var trainOffer;
  TrainOfferCard(
      {Key? key,
      this.isLarge = false,
      this.elevation = 4,
      required this.trainOffer})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    String departure_time = trainOffer.DepartureTimes.first.toString();
    String departure_station = trainOffer.stations.first;
    String arrival_time = trainOffer.DepartureTimes.last.toString();
    String arrival_station = trainOffer.stations.last;
    String time = trainOffer.ArrivalTimes.last
        .difference(trainOffer.DepartureTimes.first)
        .toString();

    return Card(
      color: Colors.transparent,
      elevation: elevation,
      margin: EdgeInsets.symmetric(horizontal: 10, vertical: 20),
      child: Container(
        padding: EdgeInsets.all(16),
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
                    Text('ODJAZD', style: TextStyle(color: Colors.white)),
                    Text(departure_time,
                        style: TextStyle(fontSize: 26, color: Colors.white)),
                    Text(
                      departure_station,
                      style: TextStyle(color: Colors.white),
                    ),
                  ],
                ),
                Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: <Widget>[
                    Text('PRZYJAZD', style: TextStyle(color: Colors.white)),
                    Text(arrival_time,
                        style: TextStyle(fontSize: 26, color: Colors.white)),
                    Text(arrival_station,
                        style: TextStyle(color: Colors.white)),
                  ],
                ),
              ],
            ),
            SizedBox(height: 8),
            Row(
              mainAxisAlignment: MainAxisAlignment.start,
              children: <Widget>[
                Icon(Icons.access_time, color: Colors.white),
                SizedBox(width: 8),
                Text(time, style: TextStyle(fontSize: 22, color: Colors.white)),
              ],
            ),
            SizedBox(height: 8),
            Divider(),
            Row(
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
            Text('Klasa 1: od 90,00 zł',
                style: TextStyle(fontSize: 25, color: Colors.white)),
            Text('Klasa 2: od 58,65 zł',
                style: TextStyle(fontSize: 25, color: Colors.white)),
            SizedBox(height: 50),
            ElevatedButton(
              onPressed: () {},
              style: ElevatedButton.styleFrom(
                backgroundColor: Colors.orange, // Background color
                foregroundColor: Colors.white, // Text Color
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(18.0),
                ),
              ),
              child: Text('Wybierz'),
            ),
          ],
        ),
      ),
    );
  }
}
