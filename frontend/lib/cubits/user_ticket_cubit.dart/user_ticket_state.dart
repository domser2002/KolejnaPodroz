class TicketState {
  final bool loading;
  final dynamic ticket;
  final List<dynamic>? tickets;
  final String error;

  TicketState({this.loading = false, this.ticket, this.tickets, this.error = ''});
}