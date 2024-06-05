import 'dart:io';

import 'package:firebase_auth/firebase_auth.dart';
import 'package:firebase_core/firebase_core.dart';
import 'package:flutter/material.dart';
import 'package:frontend/utils/http_requests.dart';
import 'package:provider/provider.dart';
import 'package:frontend/classes/user_provider.dart';

class UserInfoPage extends StatelessWidget {
  UserInfoPage({super.key});
  HttpRequests reqest = HttpRequests();
  void _confirmDeleteAccount(BuildContext context) {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: const Text('Usuń konto'),
          content: const Text('Czy na pewno chcesz usunąć swoje konto?'),
          actions: [
            TextButton(
              child: const Text('Anuluj'),
              onPressed: () {
                Navigator.of(context).pop();
              },
            ),
            TextButton(
              child: const Text('Usuń'),
              onPressed: () {
                reqest.deleteUser(Provider.of<UserProvider>(context, listen: false).user!.id);
                FirebaseAuth.instance.currentUser!.delete();
                Navigator.of(context).pop();
                ScaffoldMessenger.of(context).showSnackBar(
                  const SnackBar(content: Text('Konto zostało usunięte')),
                );
              },
            ),
          ],
        );
      },
    );
  }

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
            SizedBox(height: MediaQuery.of(context).size.height * 0.02),
            Text(
              'Punkty lojalnościowe: ${user?.loyaltyPoints ?? "Brak danych"}',
              style: const TextStyle(fontSize: 18),
            ),
            SizedBox(height: MediaQuery.of(context).size.height * 0.05),
            Center(
              child: ElevatedButton(
                onPressed: () => _confirmDeleteAccount(context),
                style: ElevatedButton.styleFrom(
                  backgroundColor: Colors.red,
                  foregroundColor: Colors.white,
                  shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(18.0),
                  ),
                ),
                child: const Text('Usuń konto'),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
