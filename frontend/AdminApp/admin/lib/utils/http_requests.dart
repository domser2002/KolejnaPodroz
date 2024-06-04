import 'package:admin/classes/complaint.dart';
import 'package:admin/classes/admin.dart';
import 'package:admin/classes/my_provider.dart';
import 'package:admin/classes/train_offer.dart';
import 'package:admin/classes/user.dart';
import 'package:firebase_auth/firebase_auth.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

class HttpRequests {
  String host = "https://localhost:7006";

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

  Future<bool> acceptAdmin(String adminId) async {
    try {
      var url = Uri.parse('$host/Admin/accept/$adminId');
      var response = await http.post(url);

      if (response.statusCode == 200) {
        print("admin accepted");
        return true;
      } else {
        print('Failed to accept admin');
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
        var complaintJson = jsonDecode(
            response.body); // This is a Map<String, dynamic>, not a List
        Complaint result =
            Complaint.fromJson(complaintJson); // Directly deserialize it
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

  Future<List<Complaint>> getAllComplaints() async {
    try {
      var url = Uri.parse('$host/Complaint/getAll');
      var response = await http.get(url);

      if (response.statusCode == 200) {
        var complaintsObjsJson = jsonDecode(response.body) as List;
        List<Complaint> result = complaintsObjsJson
            .map((complaintJson) => Complaint.fromJson(complaintJson))
            .toList();
        print("complaints loaded");
        return result;
      } else {
        print('Failed to load complaint');
      }
    } catch (e) {
      print(e.toString());
    }
    return []; // Return null if there's an error or if the complaint doesn't load
  }

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

  Future<List<MyProvider>?> getAllProviders() async {
    try {
      var url = Uri.parse('$host/Admin/getAllProviders');
      var response = await http.get(url);

      if (response.statusCode == 200) {
        var providersObjsJson = jsonDecode(response.body) as List;
        List<MyProvider> result = providersObjsJson
            .map((providersJson) => MyProvider.fromJson(providersJson))
            .toList();
        print("providers loaded");
        return result;
      } else {
        print('Failed to load providers');
      }
    } catch (e) {
      print(e.toString());
    }
    return []; // Return null if there's an error or if the complaint doesn't load
  }

  Future<List<MyUser>?> getAllUsers() async {
    try {
      var url = Uri.parse('$host/Admin/getAllUsers');
      var response = await http.get(url);

      if (response.statusCode == 200) {
        var usersObjsJson = jsonDecode(response.body) as List;
        List<MyUser> result = usersObjsJson
            .map((usersJson) => MyUser.fromJson(usersJson))
            .toList();
        print("users loaded");
        return result;
      } else {
        print('Failed to load users');
      }
    } catch (e) {
      print(e.toString());
    }
    return []; // Return null if there's an error or if the complaint doesn't load
  }

  Future<List<MyAdmin>?> getAllAdmins() async {
    try {
      var url = Uri.parse('$host/Admin/getAllAdmins');
      var response = await http.get(url);

      if (response.statusCode == 200) {
        var usersObjsJson = jsonDecode(response.body) as List;
        List<MyAdmin> result = usersObjsJson
            .map((usersJson) => MyAdmin.fromJson(usersJson))
            .toList();
        print("admins loaded");
        return result;
      } else {
        print('Failed to load admins');
      }
    } catch (e) {
      print(e.toString());
    }
    return []; // Return null if there's an error or if the complaint doesn't load
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
}
