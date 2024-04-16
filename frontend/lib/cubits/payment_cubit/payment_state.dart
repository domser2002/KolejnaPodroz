class PaymentState {
  final bool loading;
  final String message;
  final String error;

  PaymentState({this.loading = false, this.message = '', this.error = ''});
}