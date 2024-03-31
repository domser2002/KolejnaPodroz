// date_picker_widget.dart
import 'package:flutter/material.dart';

class DatePickerWidget extends StatelessWidget {
  final TextEditingController controller;
  final String hintText;

  DatePickerWidget({
    Key? key,
    required this.controller,
    required this.hintText,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return TextFormField(
      controller: controller,
      decoration: InputDecoration(
        labelText: hintText,
        prefixIcon: const Icon(Icons.calendar_today),
      ),
      readOnly: true,
      onTap: () async {
        DateTime? pickedDate = await showDatePicker(
          context: context,
          initialDate: DateTime.now(),
          firstDate: DateTime.now().subtract(Duration(days: 0)),
          lastDate: DateTime(2101),
        );
        if (pickedDate != null) {
          String formattedDate = "${pickedDate.toLocal()}".split(' ')[0];
          controller.text = formattedDate;
        }
      },
    );
  }
}
