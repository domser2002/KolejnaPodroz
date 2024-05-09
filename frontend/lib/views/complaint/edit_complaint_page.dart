import 'package:flutter/material.dart';
import 'package:frontend/classes/complaint.dart';
import 'package:frontend/utils/http_requests.dart';
import 'package:http/http.dart' as http;

class EditComplaintPage extends StatelessWidget {
  final TextEditingController reasonController = TextEditingController();
  final int complaintId;

  EditComplaintPage({required this.complaintId, Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    Size screenSize = MediaQuery.of(context).size;
    double winWidth = screenSize.width;
    double winHeight = screenSize.height;
    HttpRequests request = HttpRequests();

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
                          'Edytuj reklamację',
                          style: TextStyle(
                            color: Colors.white,
                            fontSize: 24,
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                        SizedBox(height: winHeight * 0.027),
                        Text(
                          "ID reklamacji: $complaintId",
                          style: const TextStyle(
                            color: Colors.white,
                            fontSize: 18,
                          ),
                        ),
                        SizedBox(height: winHeight * 0.027),
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
                        onPressed: () async {
                          if (reasonController.text.isNotEmpty) {
                            // Fetch the existing complaint
                            Complaint? complaint = await request.getComplaint(complaintId.toString());
                            if (complaint != null) {
                              // Update the complaint's content with the new reason
                              complaint.content = reasonController.text;

                              // Prepare the updated data as a Map
                              Map<String, dynamic> updatedData = {
                                'ticketId': complaint.ticketId,
                                'content': complaint.content, 
                                'isResponded': complaint.isResponded,
                                'title': complaint.title,
                                'response': complaint.response,
                                'complainantID': complaint.complainantID,
                                'id': complaint.id
                              };

                              // Update the complaint on the server
                              await request.editComplaint(complaintId.toString(), updatedData);

                              // Navigate back
                              
                              Navigator.pop(context);
                            } else {
                              print("No complaint found with that ID");
                              Navigator.pop(context);
                            }
                          }
                        },
                        style: ElevatedButton.styleFrom(
                          foregroundColor: Colors.white,
                          backgroundColor: Colors.orange,
                        ),
                        child: const Text('Edytuj Reklamację'),
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
