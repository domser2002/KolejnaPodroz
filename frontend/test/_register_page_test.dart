// import 'package:flutter/material.dart';
// import 'package:flutter_test/flutter_test.dart';
// import 'package:frontend/classes/http_service.dart';
// import 'package:frontend/views/auth/register_page.dart';
// import 'package:mockito/mockito.dart';
// import 'package:provider/provider.dart';
// import 'package:frontend/classes/user_provider.dart';
// import 'package:frontend/classes/auth_service.dart';

// // Mock classes
// class MockAuthService extends Mock implements AuthService {}
// class MockHttpService extends Mock implements HttpService {}
// class MockUserProvider extends Mock implements UserProvider {}

// void main() {
//   group('RegistrationPage', () {
//     late MockAuthService mockAuthService;
//     late MockHttpService mockHttpService;
//     late MockUserProvider mockUserProvider;

//     setUp(() {
//       mockAuthService = MockAuthService();
//       mockHttpService = MockHttpService();
//       mockUserProvider = MockUserProvider();
//     });

//     Widget createTestWidget() {
//       return MultiProvider(
//         providers: [
//           Provider<AuthService>(create: (_) => mockAuthService),
//           Provider<HttpService>(create: (_) => mockHttpService),
//           ChangeNotifierProvider<UserProvider>(create: (_) => mockUserProvider),
//         ],
//         child: MaterialApp(
//           home: Scaffold(body: RegistrationPage()),
//         ),
//       );
//     }

//     testWidgets('should call registerWithEmailAndPassword when register button is pressed', (WidgetTester tester) async {
//       // Arrange
//       const testEmail = 'test@example.com';
//       const testPassword = 'password';
//       final testUserData = {
//         'firstName': 'Test',
//         'lastName': 'User',
//         'email': testEmail,
//         'firebaseID': 'firebase123'
//       };

//       // Using Future.value() for Future<void>
//       when(mockAuthService.registerWithEmailAndPassword(testEmail, testPassword))
//             .thenAnswer((_) async => Future.value(null));
//       when(mockHttpService.createUser(testUserData)).thenAnswer((_) async => Future.value({
//         'id': '123',
//         'firstName': 'Test',
//         'lastName': 'User',
//         'email': testEmail,
//         'firebaseID': 'firebase123'
//       }));
//       when(mockHttpService.authoriseUser('firebase123')).thenAnswer((_) async => Future.value(null));

//       // Build the widget tree
//       await tester.pumpWidget(createTestWidget());

//       // Enter text into the fields
//       await tester.enterText(find.byType(TextFormField).at(0), 'Test');
//       await tester.enterText(find.byType(TextFormField).at(1), 'User');
//       await tester.enterText(find.byType(TextFormField).at(2), testEmail);
//       await tester.enterText(find.byType(TextFormField).at(3), testPassword);
//       await tester.enterText(find.byType(TextFormField).at(4), testPassword);
//       await tester.pumpAndSettle();  // Make sure the UI updates after entering text

//       // Tap the register button
//       await tester.tap(find.byType(ElevatedButton));
//       await tester.pumpAndSettle();

//       // Assert
//       verify(mockAuthService.registerWithEmailAndPassword(testEmail, testPassword)).called(1);
//       verify(mockHttpService.createUser(testUserData)).called(1);
//       verify(mockHttpService.authoriseUser('firebase123')).called(1);
//     });
//   });
// }
