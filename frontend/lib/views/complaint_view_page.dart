import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:frontend/widgets/input_button_widget.dart';
import 'package:frontend/widgets/socialmedia_button.dart';

class ComplaintViewPage extends StatelessWidget {
  final TextEditingController reasonController = TextEditingController();

  ComplaintViewPage(
      {required this.ticketId,
      required this.description,
      required this.reviewed,
      Key? key})
      : super(key: key);
  final String ticketId;
  final String description;
  final bool reviewed;

  @override
  Widget build(BuildContext context) {
    String rev = reviewed == true ? "rozpatrzona" : "nierozpatrzona";
    rev = "Stan: " + rev;
    reasonController.text = description;
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
        title: const Text(''),
        leading: IconButton(
          icon: const Icon(Icons.close),
          onPressed: () => Navigator.pop(context),
        ),
      ),
      body: Stack(
        fit: StackFit.expand,
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
              padding:
                  const EdgeInsets.symmetric(vertical: 200, horizontal: 300),
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
                    padding: const EdgeInsets.symmetric(
                        horizontal: 200, vertical: 50),
                    child: Column(
                      mainAxisSize: MainAxisSize.min,
                      children: [
                        const Text(
                          'Podgląd reklamacji',
                          style: TextStyle(
                            color: Colors.white,
                            fontSize: 24,
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                        const SizedBox(height: 20),
                        Container(
                          child: Row(
                            mainAxisAlignment: MainAxisAlignment.center,
                            children: [
                              Text(
                                "ID biletu: " + ticketId,
                                style: TextStyle(
                                  color: Colors.white,
                                  fontSize: 18,
                                ),
                              ),
                              SizedBox(width: 30),
                              Text(
                                rev,
                                style: TextStyle(
                                  color: Colors.white,
                                  fontSize: 18,
                                ),
                              )
                            ],
                          ),
                        ),
                        const SizedBox(height: 20),
                        Container(
                          margin: EdgeInsets.only(bottom: 10),
                          child: TextField(
                            enabled: false,
                            controller: reasonController,
                            decoration: InputDecoration(
                              filled: true,
                              fillColor: Colors.white,
                              constraints: BoxConstraints.expand(
                                  width: 500, height: 200),
                              labelText: "Wyjaśnienie",
                            ),
                            obscureText: false,
                            maxLines: 8,
                            maxLength: 500,
                          ),
                        ),
                        const SizedBox(height: 20),
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
