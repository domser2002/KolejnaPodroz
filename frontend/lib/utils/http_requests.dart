import 'package:frontend/classes/complaint.dart';
import 'package:frontend/classes/ticket.dart';
import 'package:frontend/classes/user.dart';
import 'package:frontend/classes/train_offer.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

class HttpRequests {
  String host = "https://localhost:7006";

  Future<dynamic> getUserAchievements() async {
    try {
      var url = Uri.parse('$host/user/achievements');
      var response = await http
          .get(url, headers: {'Authorization': 'Bearer twoj_token_dostepu'});

      if (response.statusCode == 200) {
        var jsonResponse = jsonDecode(response.body);
        print('achivement loaded');
        return jsonResponse;
      } else {
        print('Failed to load achievements');
      }
    } catch (e) {
      print(e.toString());
    }
  }

  Future<List<TrainOffer>> searchTrains(
      String departure, String destination, String date) async {
    if (departure.isEmpty || destination.isEmpty || date.isEmpty) {
      print("Wszystkie pola muszą być wypełnione.");
      return List.empty();
    }

    try {
      var uri = Uri.parse('$host/Connection/searchConnections')
          .replace(queryParameters: {
        'from': departure,
        'to': destination,
        'when': date,
      });
      var response = await http.get(
        uri,
        headers: <String, String>{
          'Content-Type': 'application/json',
        },
      );

      if (response.statusCode == 200) {
        var jsonResponse = json.decode(response.body) as List<dynamic>;
        print("connection found");
        var d = parseTrainOffers(jsonResponse);
        print(d.length);
        return parseTrainOffers(jsonResponse);
      } else {
        print("Błąd serwera: ${response.statusCode}");
        return List.empty();
      }
    } catch (e) {
      print("Błąd połączenia: $e");
      return List.empty();
    }
  }

  Future<dynamic> createUser(Map<String, dynamic> userData) async {
    try {
      var url = Uri.parse('$host/User/create');
      var response = await http.post(
        url,
        body: jsonEncode(userData),
        headers: {'Content-Type': 'application/json'},
      );

      if (response.statusCode == 200) {
        var jsonResponse = jsonDecode(response.body);
        print('user created');
        return jsonResponse;
      } else {
        print('Failed to create user');
      }
    } catch (e) {
      print(e.toString());
    }
  }

  Future<bool> verifyUser(int userID) async {
    try {
      var url = Uri.parse('$host/User/verify/$userID');
      var response = await http.post(url);

      if (response.statusCode == 200) {
        print("user verified");
        return true;
      } else {
        print('Failed to verify user');
        return false;
      }
    } catch (e) {
      print(e.toString());
      return false;
    }
  }

  Future<dynamic> authoriseUser(String firebaseID) async {
    try {
      var url = Uri.parse('$host/User/authorise/$firebaseID?token=$firebaseID');
      var response = await http.post(url);

      if (response.statusCode == 200) {
        var jsonResponse = jsonDecode(response.body);
        print("user authorised");
        return jsonResponse;
      } else {
        print('Failed to authorise user');
      }
    } catch (e) {
      print(e.toString());
    }
  }

  Future<bool> deleteUser(int userID) async {
    try {
      var url = Uri.parse('$host/User/delete/$userID');
      var response = await http.delete(url);

      if (response.statusCode == 200) {
        print("user deleted");
        return true;
      } else {
        print('Failed to delete user');
        return false;
      }
    } catch (e) {
      print(e.toString());
      return false;
    }
  }

  Future<dynamic> getTicketById(String ticketId) async {
    try {
      var url = Uri.parse('$host/Ticket/$ticketId');
      var response = await http.get(url);

      if (response.statusCode == 200) {
        var ticket = jsonDecode(response.body);
        print("ticket found");
        return ticket;
      } else {
        print('Failed to load ticket');
      }
    } catch (e) {
      print(e.toString());
    }
  }

Future<List<Ticket>> getTicketsByUser(int userId) async {
    try {
      var url = Uri.parse('$host/Ticket/byUser/0?userID=$userId');
      var response = await http.get(url);

      if (response.statusCode == 200) {
        List<dynamic> ticketsJson = jsonDecode(response.body);
        return ticketsJson.map((json) => Ticket.fromJson(json)).toList();
      } else {
        print('Nie udało się pobrać biletów użytkownika');
      }
    } catch (e) {
      print(e.toString());
    }
    return [];
  }

  Future<dynamic> createTicket(Map<String, dynamic> ticketData) async {
    try {
      var url = Uri.parse('$host/Ticket/create');
      var response = await http.post(url,
          body: jsonEncode(ticketData),
          headers: {'Content-Type': 'application/json'});

      if (response.statusCode == 201) {
        var ticket = jsonDecode(response.body);
        print("ticket created");
        return ticket;
      } else {
        print('Nie udało się utworzyć biletu');
      }
    } catch (e) {
      print(e.toString());
    }
  }

  Future<bool> editTicket(
      String ticketId, Map<String, dynamic> updatedData) async {
    try {
      var url = Uri.parse('$host/Ticket/edit');
      var response = await http.put(url,
          body: jsonEncode(updatedData),
          headers: {'Content-Type': 'application/json'});

      if (response.statusCode == 200) {
        print("ticket edited");
        return true;
      } else {
        print('Nie udało się edytować biletu');
        return false;
      }
    } catch (e) {
      print(e.toString());
      return false;
    }
  }

  Future<bool> deleteTicket(String ticketId) async {
    try {
      var url = Uri.parse('$host/Ticket/delete/$ticketId');
      var response = await http.delete(url);

      if (response.statusCode == 200) {
        print("ticket deleted");
        return true;
      } else {
        print('Nie udało się usunąć biletu');
        return false;
      }
    } catch (e) {
      print(e.toString());
      return false;
    }
  }

  Future<dynamic> createAdmin(Map<String, dynamic> adminData) async {
    try {
      var url = Uri.parse('$host/Admin/create');
      var response = await http.post(
        url,
        body: jsonEncode(adminData),
        headers: {'Content-Type': 'application/json'},
      );

      if (response.statusCode == 200) {
        var data = jsonDecode(response.body);
        print("admin created");
        return data;
      } else {
        print('Failed to create admin');
      }
    } catch (e) {
      print(e.toString());
    }
  }

  Future<bool> verifyAdmin(String adminId) async {
    try {
      var url = Uri.parse('$host/Admin/verify/$adminId');
      var response = await http.post(url);

      if (response.statusCode == 200) {
        print("admin verified");
        return true;
      } else {
        print('Failed to verify admin');
        return false;
      }
    } catch (e) {
      print(e.toString());
      return false;
    }
  }

  Future<bool> authoriseAdmin(String adminId) async {
    try {
      var url = Uri.parse('$host/Admin/authorise/$adminId');
      var response = await http.post(url);

      if (response.statusCode == 200) {
        print("admin authorised");
        return true;
      } else {
        print('Failed to authorise admin');
        return false;
      }
    } catch (e) {
      print(e.toString());
      return false;
    }
  }

  Future<bool> deleteAdmin(String adminId) async {
    try {
      var url = Uri.parse('$host/Admin/delete/$adminId');
      var response = await http.delete(url);

      if (response.statusCode == 200) {
        print("admin deleted");
        return true;
      } else {
        print('Failed to delete admin');
        return false;
      }
    } catch (e) {
      print(e.toString());
      return false;
    }
  }

Future<Complaint?> makeComplaint(Map<String, dynamic> complaintData) async {
  try {
    var url = Uri.parse('$host/Complaint/make');
    var response = await http.post(
      url,
      body: jsonEncode(complaintData),
      headers: {'Content-Type': 'application/json'},
    );

    if (response.statusCode == 200) {
      print("Complaint made");
      return Complaint.fromJson(jsonDecode(response.body));
    } else {
      print('Failed to make complaint: ${response.body}');
    }
  } catch (e) {
    print(e.toString());
  }
  return null;
}



Future<bool> removeComplaint(String complaintId) async {
  try {
    var url = Uri.parse('$host/Complaint/remove/$complaintId');
    var response = await http.delete(url);

    if (response.statusCode == 200) {
      print("Complaint removed");
      return true;
    } else {
      print('Failed to remove complaint: ${response.body}');
      return false;
    }
  } catch (e) {
    print(e.toString());
    return false;
  }
}

Future<bool> editComplaint(String complaintId, Map<String, dynamic> updatedData) async {
  try {
    var url = Uri.parse('$host/Complaint/edit/$complaintId');
    var response = await http.patch(
      url,
      body: jsonEncode(updatedData),
      headers: {'Content-Type': 'application/json'},
    );

    if (response.statusCode == 200) {
      print("Complaint edited");
      return true;
    } else {
      print('Failed to edit complaint: ${response.body}');
      return false;
    }
  } catch (e) {
    print(e.toString());
    return false;
  }
}


Future<Complaint?> getComplaint(String complaintId) async {
  try {
    var url = Uri.parse('$host/Complaint/get/$complaintId');
    var response = await http.get(url);

    if (response.statusCode == 200) {
      var complaintJson = jsonDecode(response.body); // This is a Map<String, dynamic>, not a List
      Complaint result = Complaint.fromJson(complaintJson); // Directly deserialize it
      print("complaint loaded");
      return result; // Return the Complaint object
    } else {
      print('Failed to load complaint');
    }
  } catch (e) {
    print(e.toString());
  }
  return null; // Return null if there's an error or if the complaint doesn't load
}


  // Future<List<Complaint>> getComplaintsByUser(int userId) async {
  //   try {
  //     var url = Uri.parse('$host/Complaint/getByUser/$userId');
  //     var response = await http.get(url);

  //     if (response.statusCode == 200) {
  //       var complaintJson = jsonDecode(
  //           response.body); // This is a Map<String, dynamic>, not a List
  //       Complaint result =
  //           Complaint.fromJson(complaintJson); // Directly deserialize it
  //       print("complaint loaded");
  //       return result; // Return the Complaint object
  //     } else {
  //       print('Failed to load complaint');
  //     }
  //   } catch (e) {
  //     print(e.toString());
  //   }
  //   return null; // Return null if there's an error or if the complaint doesn't load
  // }

  Future<List<Complaint>> getComplaintsByUser(int userId) async {
    try {
      var url = Uri.parse('$host/Complaint/getByUser/$userId');
      var response = await http.get(url);

      if (response.statusCode == 200) {
        var complaintsObjsJson = jsonDecode(response.body) as List;
        List<Complaint> result = complaintsObjsJson
            .map((complaintJson) => Complaint.fromJson(complaintJson))
            .toList();
        print("complaints loaded");
        return result;
      } else {
        print('Failed to load complaints');
      }
    } catch (e) {
      print(e.toString());
    }
    return []; // Add a return statement here
  }

  Future<bool> processPayment(String paymentId) async {
    try {
      var url = Uri.parse('$host/Payment/process/$paymentId');
      var response = await http.post(url);

      if (response.statusCode == 200) {
        print('Payment processed successfully');
        return true;
      } else {
        print('Failed to process payment');
        return false;
      }
    } catch (e) {
      print(e.toString());
      return false;
    }
  }

  Future<dynamic> getRankingByUser(String userId) async {
    try {
      var url = Uri.parse('$host/Ranking/byUser/$userId');
      var response = await http.get(url);

      if (response.statusCode == 200) {
        var ranking = jsonDecode(response.body);
        print("ranking loaded");
        return ranking;
      } else {
        print('Failed to load ranking');
      }
    } catch (e) {
      print(e.toString());
    }
  }

  // Function to update ranking by user ID
  Future<bool> updateRankingByUser(
      String userId, Map<String, dynamic> data) async {
    try {
      var url = Uri.parse('$host/Ranking/update/byUser/$userId');
      var response = await http.put(
        url,
        body: jsonEncode(data),
        headers: {'Content-Type': 'application/json'},
      );

      if (response.statusCode == 200) {
        print("ranking updated");
        return true;
      } else {
        print('Failed to update ranking');
        return false;
      }
    } catch (e) {
      print(e.toString());
      return false;
    }
  }

  Future<dynamic> getProvider(String providerId) async {
    try {
      var url = Uri.parse('$host/Provider/$providerId');
      var response = await http.get(url);

      if (response.statusCode == 200) {
        var provider = jsonDecode(response.body);
        print("provider loaded");
        return provider;
      } else {
        return ('Failed to load provider');
      }
    } catch (e) {
      print(e.toString());
    }
  }

  Future<bool> addProvider(
      String providerId, Map<String, dynamic> providerData) async {
    try {
      var url = Uri.parse('$host/Provider/add/$providerId');
      var response = await http.post(
        url,
        body: jsonEncode(providerData),
        headers: {'Content-Type': 'application/json'},
      );

      if (response.statusCode == 200) {
        print("provider loaded");
        return true;
      } else {
        print('Failed to add provider');
        return false;
      }
    } catch (e) {
      print(e.toString());
      return false;
    }
  }

  Future<bool> editProvider(
      String providerId, Map<String, dynamic> updatedData) async {
    try {
      var url = Uri.parse('$host/Provider/edit/$providerId');
      var response = await http.put(
        url,
        body: jsonEncode(updatedData),
        headers: {'Content-Type': 'application/json'},
      );

      if (response.statusCode == 200) {
        print("povider edited");
        return true;
      } else {
        print('Failed to update provider data');
        return false;
      }
    } catch (e) {
      print(e.toString());
      return false;
    }
  }

  Future<bool> deleteProvider(String providerId) async {
    try {
      var url = Uri.parse('$host/Provider/delete/$providerId');
      var response = await http.delete(url);

      if (response.statusCode == 200) {
        print("provider deleted");
        return true;
      } else {
        print('Failed to delete provider');
        return false;
      }
    } catch (e) {
      print(e.toString());
      return false;
    }
  }

  Future<MyUser?> getUser(String userId) async {
    try {
      var url = Uri.parse('$host/User/$userId');
      var response = await http.get(url);

      if (response.statusCode == 200) {
        // Parsowanie odpowiedzi JSON do obiektu User
        var userData = jsonDecode(response.body);
        MyUser user = MyUser.fromJson(
            userData); // Zakładając, że masz klasę User z metodą fromJson

        // Zwrócenie użytkownika
        return user;
      } else {
        // Obsługa nieudanej odpowiedzi
        return null; // Zwróć null, jeśli pobranie danych nie powiedzie się
      }
    } catch (e) {
      // Obsługa błędów związanych z połączeniem lub innymi problemami
      print(e.toString());
      return null; // Zwróć null, jeśli wystąpi błąd
    }
  }
  Future<void> updateLoyaltyPoints(int userID, int newPoints, String? firstName, String? lastName, String? email) async {
    final url = Uri.parse('$host/User/edit');

    final Map<String, dynamic> requestBody = {
      'userID': userID,
      'loyaltyPoints': newPoints,
      'firstName': firstName,
      'lastName': lastName,
      'email': email,
    };

    final response = await http.patch(
      url,
      headers: {
        'Content-Type': 'application/json',
      },
      body: json.encode(requestBody),
    );

    if (response.statusCode == 200) {
      print('Loyalty points updated successfully');
    } else {
      print('Failed to update loyalty points: ${response.statusCode}');
      print('Response body: ${response.body}');
    }
  }
}
