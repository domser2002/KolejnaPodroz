
abstract class UserState {}

class UserInitial extends UserState {}

class UserLoading extends UserState {}

class UserCreated extends UserState {
  final Map<String, dynamic> userData;

  UserCreated(this.userData);
}

class UserVerified extends UserState {}

class UserAuthorised extends UserState {}

class UserDeleted extends UserState {}

class UserError extends UserState {
  final String message;

  UserError(this.message);
}
