import 'package:flutter/material.dart';

class DatePickerWidget extends StatefulWidget {
  final TextEditingController controller;
  final Color backgroundColor;

  const DatePickerWidget({
    Key? key,
    required this.controller,
    this.backgroundColor = Colors.white,
  }) : super(key: key);

  @override
  _DatePickerWidgetState createState() => _DatePickerWidgetState();
}

class _DatePickerWidgetState extends State<DatePickerWidget> {
  late DateTime selectedDate;

  @override
  void initState() {
    super.initState();
    selectedDate = DateTime.now();
  }

  Future<void> _selectDate(BuildContext context) async {
    final DateTime? picked = await showDatePicker(
      context: context,
      initialDate: selectedDate,
      firstDate: DateTime.now().subtract(const Duration(days: 0)),
      lastDate: DateTime(2101),
    );
    if (picked != null && picked != selectedDate) {
      setState(() {
        selectedDate = picked;
        widget.controller.text = "${picked.toLocal()}".split(' ')[0];
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return MouseRegion(
      cursor: SystemMouseCursors.click, // Ustawienie kursora na ikonę "lapki" po najechaniu
      child: GestureDetector(
        onTap: () => _selectDate(context),
        child: Container(
          padding: const EdgeInsets.all(15.0), // Zwiększ padding wokół GestureDetector
          decoration: BoxDecoration(
            color: widget.backgroundColor,
            borderRadius: BorderRadius.circular(30.0),
          ),
          child: Stack(
            children: [
              const Align(
                alignment: Alignment.centerLeft, // Wyrównanie ikony i tekstu do lewej strony
                child: Row(
                  children: [
                     Icon(Icons.calendar_month, color: Colors.black),
                     SizedBox(width: 25), // Równomierne odstępy między ikoną a tekstem
                     Text(
                      "KIEDY",
                      style: TextStyle(color: Colors.black, fontWeight: FontWeight.bold),
                    ),
                  ],
                ),
              ),
              Align(
                alignment: Alignment.center,
                child: Text(
                  widget.controller.text,
                  style: const TextStyle(color: Colors.black, fontWeight: FontWeight.bold),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
