import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/material.dart';
import 'package:frontend/classes/train_offer.dart';
import 'package:frontend/classes/user.dart';
import 'package:frontend/classes/user_provider.dart';
import 'package:frontend/utils/http_requests.dart';
import 'package:frontend/views/auth/login_page.dart';
import 'package:frontend/views/auth/register_page.dart';
import 'package:frontend/views/landing_page.dart';
import 'package:frontend/views/user_profile_page.dart';
import 'package:provider/provider.dart';

class BuyTicketPage extends StatefulWidget {
  final TrainOffer trainOffer;
  BuyTicketPage({super.key, required this.trainOffer});

  @override
  _BuyTicketPageState createState() => _BuyTicketPageState();
}

class _BuyTicketPageState extends State<BuyTicketPage> {
  HttpRequests request = HttpRequests();
  bool _termsAccepted = false;

  @override
  Widget build(BuildContext context) {
    Size screenSize = MediaQuery.of(context).size;
    double winWidth = screenSize.width;
    double winHeight = screenSize.height;
    UserProvider userProvider = Provider.of<UserProvider>(context);

    int dmin = widget.trainOffer.stops.first.departureTime.minute;
    String dMin = dmin < 10
        ? "0${widget.trainOffer.stops.first.departureTime.minute}"
        : widget.trainOffer.stops.first.departureTime.minute.toString();
    int amin = widget.trainOffer.stops.last.arrivalTime.minute;
    String aMin = amin < 10
        ? "0${widget.trainOffer.stops.last.arrivalTime.minute}"
        : widget.trainOffer.stops.last.arrivalTime.minute.toString();

    String departureTime = '${widget.trainOffer.stops.first.departureTime.hour}:$dMin';
    String departureStation = widget.trainOffer.stops.first.stationID.toString(); // Change to appropriate station name
    String arrivalTime = '${widget.trainOffer.stops.last.arrivalTime.hour}:$aMin';
    String arrivalStation = widget.trainOffer.stops.last.stationID.toString(); // Change to appropriate station name
    String time =
        "${widget.trainOffer.stops.last.arrivalTime.difference(widget.trainOffer.stops.first.departureTime).inMinutes}min";

    return Scaffold(
      bottomNavigationBar: BottomAppBar(
          color: Colors.white,
          height: winHeight * 0.07,
          child: const Center(
              child: Stack(
            fit: StackFit.passthrough,
            children: [
              Text("©Kolejna Podróż 2024",
                  style: TextStyle(color: Colors.black)),
            ],
          ))),
      appBar: AppBar(
        backgroundColor: Colors.white,
        elevation: 0,
        actions: [
          StreamBuilder<User?>(
            stream: FirebaseAuth.instance.authStateChanges(),
            builder: (context, snapshot) {
              if (snapshot.hasData) {
                // Użytkownik jest zalogowany
                return Row(
                  children: [
                    if (userProvider.user != null)
                      Padding(
                        padding: const EdgeInsets.only(right: 8.0),
                        child: Text(
                          'Cześć, ${userProvider.user!.firstName}',
                          style: const TextStyle(
                              fontSize: 16, fontWeight: FontWeight.bold),
                        ),
                      ),
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
      extendBodyBehindAppBar: true,
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
            child: SingleChildScrollView(
              padding: EdgeInsets.symmetric(
                  vertical: winHeight * 0.27, horizontal: winWidth * 0.2),
              child: Container(
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
                child: Card(
                  color: Colors.transparent,
                  elevation: 8,
                  shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(40),
                  ),
                  child: Padding(
                    padding: EdgeInsets.symmetric(
                        horizontal: winWidth * 0.07,
                        vertical: winHeight * 0.07),
                    child: Column(
                      mainAxisSize: MainAxisSize.min,
                      children: [
                        const Text(
                          'Podsumowanie zakupu biletu',
                          style: TextStyle(
                              fontSize: 24,
                              fontWeight: FontWeight.bold,
                              color: Colors.white),
                        ),
                        SizedBox(height: winHeight * 0.022),
                        const Text(
                          'Szczegóły biletu:',
                          style: TextStyle(color: Colors.white),
                        ),
                        SizedBox(height: winHeight * 0.022),
                        Text(
                          'Odjazd: $departureTime z $departureStation',
                          style: TextStyle(color: Colors.white),
                        ),
                        Text(
                          'Przyjazd: $arrivalTime do $arrivalStation',
                          style: TextStyle(color: Colors.white),
                        ),
                        Text(
                          'Czas trwania: $time',
                          style: TextStyle(color: Colors.white),
                        ),
                        SizedBox(height: winHeight * 0.022),
                        Row(
                          children: [
                            Checkbox(
                              value: _termsAccepted,
                              onChanged: (bool? value) {
                                setState(() {
                                  _termsAccepted = value!;
                                });
                              },
                            ),
                            const Flexible(
                              child: Text(
                                'Akceptuję regulamin serwisu',
                                style: TextStyle(color: Colors.white),
                              ),
                            ),
                          ],
                        ),
                        SizedBox(height: winHeight * 0.022),
                        ElevatedButton(
                          onPressed: _termsAccepted
                              ? () async {
                                var ticketData = {
                                  "ownerID": 0,
                                  "connectionID": widget.trainOffer.id,
                                  "purchased": true,
                                  "id": 0
                                };
                                if(userProvider.user != null)
                                {
                                  ticketData = {
                                    "ownerID": userProvider.user!.id,
                                    "connectionID": widget.trainOffer.id,
                                    "purchased": true,
                                    "id": 0
                                  };
                                  int newPoints = userProvider.user!.loyaltyPoints + 1;
                                  await request.deleteUser(userProvider.user!.id);
                                  var userData = {
                                      'firstName': userProvider.user!.firstName,
                                      'lastName': userProvider.user!.lastName,
                                      'email':userProvider.user!.email,
                                      'firebaseID': FirebaseAuth.instance.currentUser!.uid,
                                      'loyaltyPoints': newPoints,
                                    };
                                   var createdUser  = await request.createUser(userData);
                                  if (createdUser != null) {

                                  MyUser user = MyUser.fromJson(createdUser);

                                  // Save user details to the provider
                                  Provider.of<UserProvider>(context, listen: false).setUser(user);

                                }
                                }
                                  ScaffoldMessenger.of(context).showSnackBar(
                                    const SnackBar(
                                      content: Text(
                                          'Bilet został pomyślnie zakupiony!'),
                                    ),
                                  );
                                  


                                  // Przejście do zakładki "Moje konto" -> "Bilety"
                                  Navigator.of(context).pushAndRemoveUntil(
                                    MaterialPageRoute(
                                      builder: (context) => LandingPage(),
                                    ),
                                    (Route<dynamic> route) => false,
                                  );
                                }
                              : null,
                          style: ElevatedButton.styleFrom(
                            backgroundColor: Colors.orange, // Background color
                            foregroundColor: Colors.white, // Text Color
                            shape: RoundedRectangleBorder(
                              borderRadius: BorderRadius.circular(18.0),
                            ),
                          ),
                          child: const Text('Kup'),
                        ),
                      ],
                    ),
                  ),
                ),
              ),
            ),
          ),
        ],
      ),
    );
  }
}
