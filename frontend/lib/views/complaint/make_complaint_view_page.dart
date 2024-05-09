import 'package:flutter/material.dart';

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
    Size screenSize = MediaQuery.of(context).size;
    double winWidth = screenSize.width;
    double winHeight = screenSize.height;

    String rev = reviewed == true ? "rozpatrzona" : "nierozpatrzona";
    rev = "Stan: $rev";
    reasonController.text = description;
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
                        horizontal: winWidth * 0.13,
                        vertical: winHeight * 0.07),
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
                        SizedBox(height: winHeight * 0.027),
                         Row(
                           mainAxisAlignment: MainAxisAlignment.center,
                           children: [
                             Text(
                               "ID biletu: $ticketId",
                               style: const TextStyle(
                                 color: Colors.white,
                                 fontSize: 18,
                               ),
                             ),
                             SizedBox(width: winWidth * 0.02),
                             Text(
                               rev,
                               style: const TextStyle(
                                 color: Colors.white,
                                 fontSize: 18,
                               ),
                             )
                           ],
                         ),
                        SizedBox(height: winHeight * 0.027),
                        Container(
                          margin: EdgeInsets.only(bottom: winHeight * 0.013),
                          child: TextField(
                            enabled: false,
                            controller: reasonController,
                            decoration: InputDecoration(
                              filled: true,
                              fillColor: Colors.white,
                              constraints: BoxConstraints.expand(
                                  width: winWidth * 0.33,
                                  height: winHeight * 0.27),
                              labelText: "Wyjaśnienie",
                            ),
                            obscureText: false,
                            maxLines: 8,
                            maxLength: 500,
                          ),
                        ),
                        SizedBox(height: winHeight * 0.027),
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
