class ComplaintState {
  final bool loading;
  final dynamic complaint;
  final List<dynamic>? complaints;
  final String error;

  ComplaintState({this.loading = false, this.complaint, this.complaints, this.error = ''});
}