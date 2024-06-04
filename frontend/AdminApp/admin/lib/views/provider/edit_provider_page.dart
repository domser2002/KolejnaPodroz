import 'package:admin/classes/my_provider.dart';
import 'package:flutter/material.dart';
import 'package:admin/classes/complaint.dart';
import 'package:admin/classes/user_provider.dart';
import 'package:admin/utils/http_requests.dart';
import 'package:provider/provider.dart';

class EditProviderPage extends StatelessWidget {
  final TextEditingController nameController = TextEditingController();
  final TextEditingController infoController = TextEditingController();
  final TextEditingController emailController = TextEditingController();

  final MyProvider provider;
  final bool editable;

  EditProviderPage({required this.provider, required this.editable, Key? key})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    Size screenSize = MediaQuery.of(context).size;
    double winWidth = screenSize.width;
    double winHeight = screenSize.height;
    HttpRequests request = HttpRequests();
    nameController.text = provider.name;
    infoController.text = provider.info;
    emailController.text = provider.email;
    return Scaffold(
      bottomNavigationBar: BottomAppBar(
          color: Colors.white,
          height: winHeight * 0.07,
          child: const Center(
              child: Stack(
            fit: StackFit.passthrough,
            children: [
              Text("©Kolejna Podróż 2024",
                  style: TextStyle(color: Color.fromARGB(255, 78, 78, 78))),
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
                          'Edytuj przewoźnika',
                          style: TextStyle(
                            color: Colors.white,
                            fontSize: 24,
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                        SizedBox(height: winHeight * 0.027),
                        Text(
                          "ID przewoźnika: ${provider.id}",
                          style: const TextStyle(
                            color: Colors.white,
                            fontSize: 18,
                          ),
                        ),
                        SizedBox(height: winHeight * 0.027),
                        TextField(
                          readOnly: editable,
                          controller: nameController,
                          decoration: const InputDecoration(
                            filled: true,
                            fillColor: Colors.white,
                            labelText: "nazwa przewoźnika",
                          ),
                          obscureText: false,
                          maxLines: 1,
                          maxLength: 50,
                        ),
                        TextField(
                          readOnly: editable,
                          controller: infoController,
                          decoration: const InputDecoration(
                            filled: true,
                            fillColor: Colors.white,
                            labelText: "dodatkowe informacje",
                          ),
                          obscureText: false,
                          maxLines: 8,
                          maxLength: 500,
                        ),
                        SizedBox(height: winHeight * 0.027),
                        TextField(
                          controller: emailController,
                          readOnly: editable,
                          decoration: const InputDecoration(
                              filled: true,
                              fillColor: Colors.white,
                              labelText: "email"),
                          obscureText: false,
                          maxLines: 1,
                          maxLength: 50,
                        ),
                        SizedBox(height: winHeight * 0.027),
                        Row(
                          mainAxisAlignment: MainAxisAlignment.center,
                          children: [
                            ElevatedButton(
                                onPressed: () async {
                                  await request
                                      .deleteProvider(provider.id.toString());
                                  Navigator.pop(context);
                                },
                                child: Text("usuń")),
                            ElevatedButton(
                              onPressed: () async {
                                print(provider.id.toString());
                                MyProvider? prov = await request
                                    .getProvider(provider.id.toString());

                                if (prov != null) {
                                  // Update the complaint's content with the new reason
                                  prov.info = infoController.text;
                                  prov.name = infoController.text;

                                  // Prepare the updated data as a Map
                                  Map<String, dynamic> updatedData = {
                                    'name': prov.name,
                                    'info': prov.info,
                                    'email': prov.email,
                                    'id': prov.id
                                  };

                                  // Update the complaint on the server
                                  await request.editProvider(
                                      provider.id.toString(), updatedData);

                                  // Navigate back

                                  Navigator.pop(context);
                                } else {
                                  print("No provider found with that ID");
                                  Navigator.pop(context);
                                }
                              },
                              style: ElevatedButton.styleFrom(
                                foregroundColor: Colors.white,
                                backgroundColor: Colors.orange,
                              ),
                              child: const Text('zakończ edycję'),
                            ),
                          ],
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
