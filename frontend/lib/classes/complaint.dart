class Complaint {
  String ticketId;
  String description;
  bool reviewed;

  Complaint(
      {required this.ticketId, this.description = "", this.reviewed = false});
}
