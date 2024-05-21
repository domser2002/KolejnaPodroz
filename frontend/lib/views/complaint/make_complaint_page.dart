import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:frontend/classes/user_provider.dart';
import 'package:http/http.dart' as http;
import 'package:provider/provider.dart';

class MakeComplaintPage extends StatelessWidget {
  final TextEditingController reasonController = TextEditingController();
  final TextEditingController titleController = TextEditingController();
  final String ticketId;

  MakeComplaintPage({required this.ticketId, Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    Size screenSize = MediaQuery.of(context).size;
    double winWidth = screenSize.width;
    double winHeight = screenSize.height;
    UserProvider userProvider = Provider.of<UserProvider>(context);

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
                          'Złóż reklamację',
                          style:   TextStyle(
                            color: Colors.white,
                            fontSize: 24,
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                        SizedBox(height: winHeight * 0.027),
                        Text(
                          "ID biletu: $ticketId",
                          style: const TextStyle(
                            color: Colors.white,
                            fontSize: 18,
                          ),
                        ),
                        SizedBox(height: winHeight * 0.027),
                        TextField(
                          controller: titleController,
                          decoration: const InputDecoration(
                            filled: true,
                            fillColor: Colors.white,
                            labelText:
                                "Tytuł reklamacji",
                          ),
                          obscureText: false,
                          maxLines: 1,
                          maxLength: 50,
                        ),
                        TextField(
                          controller: reasonController,
                          decoration: const InputDecoration(
                            filled: true,
                            fillColor: Colors.white,
                            labelText:
                                "Wyjaśnij dlaczego chcesz zwrócić swój bilet",
                          ),
                          obscureText: false,
                          maxLines: 8,
                          maxLength: 500,
                        ),
                        SizedBox(height: winHeight * 0.027),
                        ElevatedButton(
                          onPressed: () {
                            if (reasonController.text.isNotEmpty && titleController.text.isNotEmpty ) {
                              makeComplaint("https://localhost:7006", {
                                'complainantID': userProvider.user!.id,
                                'title': titleController.text,
                                'response': "",
                                'content': reasonController.text,
                              });
                            }
                            Navigator.pop(context);
                          },
                          style: ElevatedButton.styleFrom(
                            foregroundColor: Colors.white,
                            backgroundColor: Colors.orange,
                          ),
                          child: const Text('Złóż Reklamację'),
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

Future<void> makeComplaint(
    String host, Map<String, dynamic> complaintData) async {
  var url = Uri.parse('$host/Complaint/make');
  try {
    var response = await http.post(
      url,
      body: jsonEncode(complaintData),
      headers: {'Content-Type': 'application/json'},
    );

    if (response.statusCode == 200) {
      print('Reklamacja została złożona pomyślnie.');
    } else {
      print('Nie udało się złożyć reklamacji: ${response.body}');
    }
  } catch (e) {
    print('Wystąpił błąd podczas składania reklamacji: $e');
  }
}
