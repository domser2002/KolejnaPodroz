import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:frontend/classes/user_provider.dart';

class UserInfoPage extends StatelessWidget {
  UserInfoPage({super.key});

  @override
  Widget build(BuildContext context) {
    var user = Provider.of<UserProvider>(context).user;

    return Center(
      child: Padding(
        padding: const EdgeInsets.all(5.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          mainAxisSize: MainAxisSize.min,
          children: [
            const Center(
              child: Text(
                'Dane użytkownika:',
                style: TextStyle(
                  fontSize: 18,
                  fontWeight: FontWeight.bold,
                ),
              ),
            ),
            SizedBox(height: MediaQuery.of(context).size.height * 0.02),
            Text(
              'Imię: ${user?.firstName ?? "Brak danych"}',
              style: const TextStyle(fontSize: 18),
            ),
            SizedBox(height: MediaQuery.of(context).size.height * 0.02),
            Text(
              'Nazwisko: ${user?.lastName ?? "Brak danych"}',
              style: const TextStyle(fontSize: 18),
            ),
            SizedBox(height: MediaQuery.of(context).size.height * 0.02),
            Text(
              'Email: ${user?.email ?? "Brak danych"}',
              style: const TextStyle(fontSize: 18),
            ),
          ],
        ),
      ),
    );
  }
}
