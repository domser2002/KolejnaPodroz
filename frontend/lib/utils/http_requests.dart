import 'package:http/http.dart' as http;
import 'dart:convert';

class http_requests {
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

  Future<dynamic> searchTrains(
      String departure, String destination, String date) async {
    if (departure.isEmpty || destination.isEmpty || date.isEmpty) {
      print("Wszystkie pola muszą być wypełnione.");
      return;
    }

    try {
      var response = await http.post(
        Uri.parse('$host/search'),
        headers: <String, String>{
          'Content-Type': 'application/json',
        },
        body: jsonEncode(<String, String>{
          'departure': departure,
          'destination': destination,
          'date': date,
        }),
      );

      if (response.statusCode == 200) {
        var jsonResponse = json.decode(response.body);
        print("connection found");
        return jsonResponse;
      } else {
        print("Błąd serwera: ${response.statusCode}");
      }
    } catch (e) {
      print("Błąd połączenia: $e");
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

  Future<bool> authoriseUser(int userID) async {
    try {
      var url = Uri.parse('$host/User/authorise/$userID');
      var response = await http.post(url);

      if (response.statusCode == 200) {
        print("user authorised");
        return true;
      } else {
        print('Failed to authorise user');
        return false;
      }
    } catch (e) {
      print(e.toString());
      return false;
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

  Future<void> getTicketsByUser(String userId) async {
    try {
      var url = Uri.parse('$host/Ticket/byUser/$userId');
      var response = await http.get(url);

      if (response.statusCode == 200) {
        var tickets = jsonDecode(response.body);
        print("ticket found");
        return tickets;
      } else {
        print('Nie udało się pobrać biletów użytkownika');
      }
    } catch (e) {
      print(e.toString());
    }
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

  Future<dynamic> makeComplaint(Map<String, dynamic> complaintData) async {
    try {
      var url = Uri.parse('$host/Complaint/make');
      var response = await http.post(
        url,
        body: jsonEncode(complaintData),
        headers: {'Content-Type': 'application/json'},
      );

      if (response.statusCode == 200) {
        var complaint = jsonDecode(response.body);
        print("complaint made");
        return complaint;
      } else {
        print('Failed to make complaint');
      }
    } catch (e) {
      print(e.toString());
    }
  }

  Future<bool> removeComplaint(String complaintId) async {
    try {
      var url = Uri.parse('$host/Complaint/remove/$complaintId');
      var response = await http.delete(url);

      if (response.statusCode == 200) {
        print("complaint removed");
        return true;
      } else {
        print('Failed to remove complaint');
        return false;
      }
    } catch (e) {
      print(e.toString());
      return false;
    }
  }

  Future<bool> editComplaint(
      String complaintId, Map<String, dynamic> updatedData) async {
    try {
      var url = Uri.parse('$host/Complaint/edit/$complaintId');
      var response = await http.patch(
        url,
        body: jsonEncode(updatedData),
        headers: {'Content-Type': 'application/json'},
      );

      if (response.statusCode == 200) {
        print("complaint edited");
        return true;
      } else {
        print('Failed to edit complaint');
        return false;
      }
    } catch (e) {
      print(e.toString());
      return false;
    }
  }

  Future<dynamic> getComplaint(String complaintId) async {
    try {
      var url = Uri.parse('$host/Complaint/get/$complaintId');
      var response = await http.get(url);

      if (response.statusCode == 200) {
        var complaint = jsonDecode(response.body);
        print("complaint loaded");
        return complaint;
      } else {
        print('Failed to load complaint');
      }
    } catch (e) {
      print(e.toString());
    }
  }

  Future<void> getComplaintsByUser(String userId) async {
    try {
      var url = Uri.parse('$host/Complaint/getByUser/$userId');
      var response = await http.get(url);

      if (response.statusCode == 200) {
        List<dynamic> complaints = jsonDecode(response.body);
        print("complaints loaded");
      } else {
        print('Failed to load complaints');
      }
    } catch (e) {
      print(e.toString());
    }
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
}
