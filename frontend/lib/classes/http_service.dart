abstract class HttpService {
  Future<void> authoriseUser(String uid);
  Future<Map<String, dynamic>?> createUser(Map<String, dynamic> userData);
  // Add other methods as needed
}
