// destination_input_widget.dart
import 'package:flutter/material.dart';

class DestinationInputWidget extends StatelessWidget {
  final TextEditingController controller;
  final String hintText;

  const DestinationInputWidget({
    Key? key,
    required this.controller,
    required this.hintText,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return TextField(
      controller: controller,
      decoration: InputDecoration(
        labelText: hintText,
        // Dodaj tutaj stylowanie według designu
      ),
    );
  }
}
