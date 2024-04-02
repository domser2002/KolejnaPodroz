import 'package:flutter/material.dart';


class ViewOffersPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Wybierz pociąg!'),
        actions: <Widget>[
          TextButton(
            onPressed: () {},
            child: Text('Zaloguj się', style: TextStyle(color: Colors.white)),
          ),
          TextButton(
            onPressed: () {},
            child: Text('Zarejestruj się', style: TextStyle(color: Colors.white)),
          ),
        ],
      ),
      body: Center(
        child: Padding(
          padding: const EdgeInsets.all(8.0),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: <Widget>[
              Expanded(
                child: ListView(
                  scrollDirection: Axis.horizontal,
                  children: <Widget>[
                    TrainOfferCard(),
                    TrainOfferCard(),
                    // Dodaj więcej TrainOfferCard widgetów, jeśli jest potrzebne
                  ],
                ),
              ),
              // Inne widgety, jeśli są potrzebne
            ],
          ),
        ),
      ),
    );
  }
}

class TrainOfferCard extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Card(
      elevation: 4,
      child: Container(
        width: 250, // Możesz dostosować szerokość do swoich potrzeb
        padding: EdgeInsets.all(16),
        child: Column(
          children: <Widget>[
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: <Widget>[
                Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: <Widget>[
                    Text('ODJAZD', style: TextStyle(color: Colors.grey)),
                    Text('13:20', style: TextStyle(fontSize: 24)),
                    Text('Poznań Główny'),
                  ],
                ),
                Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: <Widget>[
                    Text('PRZYJAZD', style: TextStyle(color: Colors.grey)),
                    Text('15:54', style: TextStyle(fontSize: 24)),
                    Text('Warszawa Centralna'),
                  ],
                ),
              ],
            ),
            SizedBox(height: 8),
            Row(
              mainAxisAlignment: MainAxisAlignment.start,
              children: <Widget>[
                Icon(Icons.access_time, color: Colors.grey),
                SizedBox(width: 8),
                Text('2:34 h', style: TextStyle(fontSize: 18)),
              ],
            ),
            SizedBox(height: 8),
            Divider(),
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: <Widget>[
                Text('IC81170', style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold)),
                Column(
                  crossAxisAlignment: CrossAxisAlignment.end,
                  children: <Widget>[
                    Text('Klasa 1: od 90,00 zł', style: TextStyle(fontSize: 16)),
                    Text('Klasa 2: od 58,65 zł', style: TextStyle(fontSize: 16)),
                  ],
                ),
              ],
            ),
            SizedBox(height: 16),
            ElevatedButton(
              onPressed: () {},
              child: Text('Wybierz'),
              style: ElevatedButton.styleFrom(
                foregroundColor: Colors.orange,
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(18.0),
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
