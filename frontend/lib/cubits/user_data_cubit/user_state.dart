class UserProfileState {
  final bool loading;
  final dynamic data;
  final String error;

  UserProfileState({this.loading = false, this.data, this.error = ''});
}