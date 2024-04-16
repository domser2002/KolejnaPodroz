import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:frontend/classes/complaint.dart';
import 'package:frontend/views/complaint_view_page.dart';

class complaint_item extends StatelessWidget {
  final Complaint complaint;

  const complaint_item({Key? key, required this.complaint}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: EdgeInsets.only(bottom: 5),
      child: ListTile(
        onTap: () async {
          Navigator.of(context).push(
            MaterialPageRoute(
              builder: (context) => ComplaintViewPage(
                ticketId: complaint.ticketId,
                description: complaint.description,
                reviewed: complaint.reviewed,
              ),
            ),
          );
        },
        shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(20)),
        contentPadding: EdgeInsets.symmetric(horizontal: 20, vertical: 7),
        tileColor: Theme.of(context).colorScheme.secondary,
        leading: Icon(complaint.reviewed
            ? Icons.check_box
            : Icons.check_box_outline_blank),
        title: Text(
          complaint.ticketId,
        ),
      ),
    );
  }
}
