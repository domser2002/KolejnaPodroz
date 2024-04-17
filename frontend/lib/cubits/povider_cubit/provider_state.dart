class ProviderState {
  final bool loading;
  final dynamic provider;
  final String error;

  ProviderState({this.loading = false, this.provider, this.error = ''});
}