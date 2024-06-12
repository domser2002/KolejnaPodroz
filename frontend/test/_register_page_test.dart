import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/material.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:frontend/classes/auth_service.dart';
import 'package:frontend/classes/http_service.dart';
import 'package:frontend/classes/user_provider.dart';
import 'package:frontend/views/auth/register_page.dart';
import 'package:mockito/mockito.dart';
import 'package:provider/provider.dart';
import 'package:mockito/annotations.dart';

import '_register_page_test.mocks.dart';


@GenerateMocks([AuthService, HttpService, UserProvider, User])
void main() {
  late MockAuthService mockAuthService;
  late MockHttpService mockHttpService;
  late MockUserProvider mockUserProvider;
  late MockUser mockUser;

  setUp(() {
    mockAuthService = MockAuthService();
    mockHttpService = MockHttpService();
    mockUserProvider = MockUserProvider();
    mockUser = MockUser();
  });

  Future<void> pumpRegistrationPage(WidgetTester tester) async {
    await tester.pumpWidget(
      MultiProvider(
        providers: [
          Provider<AuthService>.value(value: mockAuthService),
          Provider<HttpService>.value(value: mockHttpService),
          ChangeNotifierProvider<UserProvider>.value(value: mockUserProvider),
        ],
        child: MaterialApp(
          home: RegistrationPage(),
        ),
      ),
    );
  }

  testWidgets('Registration button triggers signUpWithEmailAndPassword', (WidgetTester tester) async {
    await pumpRegistrationPage(tester);

    // Enter text in the fields
    await tester.enterText(find.byType(TextField).at(0), 'John');
    await tester.enterText(find.byType(TextField).at(1), 'Doe');
    await tester.enterText(find.byType(TextField).at(2), 'test@example.com');
    await tester.enterText(find.byType(TextField).at(3), 'password123');
    await tester.enterText(find.byType(TextField).at(4), 'password123');

    // Ensure the button is visible before tapping it
    final signUpButton = find.byKey(Key('signUpButton'));
    await tester.ensureVisible(signUpButton);

    // Stub the currentUser method
    when(mockAuthService.currentUser).thenReturn(mockUser);
    when(mockUser.uid).thenReturn('uid');

    // Stub the registerWithEmailAndPassword method
    when(mockAuthService.registerWithEmailAndPassword(any, any)).thenAnswer((_) async => null);

    // Stub the createUser method with appropriate mock data
    when(mockHttpService.createUser(any)).thenAnswer((_) async => {
      'id': 1, // Ensure this matches the expected type in MyUser
      'firstName': 'John',
      'lastName': 'Doe',
      'email': 'test@example.com',
      'birthDate': '2000-01-01T00:00:00.000Z', // Ensure this is a valid DateTime string
      'preferedSeatType': 1,
      'preferedSeatLocation': 2,
      'loyaltyPoints': 100
    });

    // Tap the sign up button
    await tester.tap(signUpButton);
    await tester.pump();

    // Verify that the signUpWithEmailAndPassword function was called
    verify(mockAuthService.registerWithEmailAndPassword('test@example.com', 'password123')).called(1);
    verify(mockHttpService.createUser({
      'firstName': 'John',
      'lastName': 'Doe',
      'email': 'test@example.com',
      'firebaseID': 'uid',
    })).called(1);
  });
}
