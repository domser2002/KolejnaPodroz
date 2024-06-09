import 'package:firebase_core/firebase_core.dart';
import 'package:flutter/material.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:frontend/views/auth/register_page.dart';
import 'package:frontend/widgets/input_button_widget.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';
import 'package:provider/provider.dart';
import 'package:firebase_auth/firebase_auth.dart';
import 'package:frontend/classes/user_provider.dart';
import 'package:frontend/utils/http_requests.dart';

// Generowanie mocków
@GenerateMocks([FirebaseAuth, UserCredential, HttpRequests, UserProvider, User])
import '_register_page_test.mocks.dart';

void main() {
  late MockFirebaseAuth mockFirebaseAuth;
  late MockHttpRequests mockHttpRequests;
  late MockUserProvider mockUserProvider;
  late MockUserCredential mockUserCredential;
  late MockUser mockFirebaseUser;

  setUp(() async {
    // Initialize mocks
    mockFirebaseAuth = MockFirebaseAuth();
    mockHttpRequests = MockHttpRequests();
    mockUserProvider = MockUserProvider();
    mockUserCredential = MockUserCredential();
    mockFirebaseUser = MockUser();

    // Set up mock behavior
    when(mockFirebaseAuth.createUserWithEmailAndPassword(
      email: anyNamed('email'),
      password: anyNamed('password'),
    )).thenAnswer((_) async => mockUserCredential);

    when(mockUserCredential.user).thenReturn(mockFirebaseUser);

    when(mockFirebaseUser.uid).thenReturn('mockFirebaseUID');

    when(mockHttpRequests.createUser(any)).thenAnswer((_) async {
      return {
        'id': 1,
        'firstName': 'John',
        'lastName': 'Doe',
        'email': 'test@example.com',
        'birthDate': '2000-01-01',
        'preferedSeatType': 1,
        'preferedSeatLocation': 1,
        'loyaltyPoints': 100,
      };
    });
  });

  testWidgets('RegistrationPage signUpWithEmailAndPassword success',
      (WidgetTester tester) async {
    // Przygotowanie widgetu
    await tester.pumpWidget(
      MultiProvider(
        providers: [
          ChangeNotifierProvider<UserProvider>.value(value: mockUserProvider),
        ],
        child: MaterialApp(
          home: RegistrationPage(),
        ),
      ),
    );

    // Upewnij się, że widgety są w pełni widoczne
    await tester.pumpAndSettle();

    // Wypełnianie pól formularza
    await tester.enterText(find.byType(InputButton).at(0), 'John');
    await tester.enterText(find.byType(InputButton).at(1), 'Doe');
    await tester.enterText(find.byType(InputButton).at(2), 'test@example.com');
    await tester.enterText(find.byType(InputButton).at(3), 'password123');
    await tester.enterText(find.byType(InputButton).at(4), 'password123');

    // Upewnij się, że formularz jest przewinięty do widocznego obszaru
    await tester.ensureVisible(find.widgetWithText(ElevatedButton, 'Zarejestruj się'));

    // Kliknięcie przycisku rejestracji
    await tester.tap(find.widgetWithText(ElevatedButton, 'Zarejestruj się'));
    await tester.pump();

    // Weryfikacja wywołań metod
    verify(mockFirebaseAuth.createUserWithEmailAndPassword(
      email: 'test@example.com',
      password: 'password123',
    )).called(1);

    verify(mockHttpRequests.createUser(any)).called(1);

    verify(mockUserProvider.setUser(any)).called(1);
  });
}
