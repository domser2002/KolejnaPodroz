import 'package:flutter/material.dart';
import 'package:admin/classes/complaint.dart';
import 'package:admin/views/complaint/make_complaint_view_page.dart';

class ComplaintItem extends StatelessWidget {
  final Complaint complaint;

  const ComplaintItem({Key? key, required this.complaint}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: const EdgeInsets.only(bottom: 5),
      child: ListTile(
        onTap: () async {
          Navigator.of(context).push(
            MaterialPageRoute(
              builder: (context) => ComplaintViewPage(
                ticketId: complaint.ticketId,
                description: complaint.content,
                reviewed: complaint.isResponded,
              ),
            ),
          );
        },
        shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(20)),
        contentPadding: const EdgeInsets.symmetric(horizontal: 20, vertical: 7),
        tileColor: Theme.of(context).colorScheme.secondary,
        leading: Icon(complaint.isResponded
            ? Icons.check_box
            : Icons.check_box_outline_blank),
        title: Text(
          complaint.ticketId,
        ),
      ),
    );
  }
}
