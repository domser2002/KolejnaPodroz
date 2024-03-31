import 'package:flutter/material.dart';

class InputButton extends StatelessWidget {
  final TextEditingController controller;
  final String labelText;
  final Icon icon;
  final String prefixText;
  final Color backgroundColor;
  final String hintText;

  const InputButton({
    Key? key,
    required this.controller,
    required this.icon,
    required this.prefixText,
    required this.backgroundColor,
    required this.labelText,
    this.hintText = '',
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: const EdgeInsets.symmetric(horizontal: 15.0),
      decoration: BoxDecoration(
        color: backgroundColor,
        borderRadius: BorderRadius.circular(30.0),
      ),
      child: TextFormField(
        controller: controller,
        style: const TextStyle(color: Colors.black),
        textAlignVertical: TextAlignVertical.center, // Dla wyśrodkowania tekstu pionowo
        decoration: InputDecoration(
          icon: Padding(
            padding: const EdgeInsets.only(right: 8.0), // Padding for icon
            child: icon,
          ),
          hintText: hintText,
          hintStyle: TextStyle(color: Colors.grey[600]),
          labelStyle: const TextStyle(color: Colors.black, fontWeight: FontWeight.bold),
          border: InputBorder.none,
          // Customowy widget dla prefix'u
          prefixIconConstraints: BoxConstraints(minWidth: 0, minHeight: 0),
          prefixIcon: Padding(
            padding: EdgeInsets.only(right: 4), // Mały odstęp między ikoną a tekstem
            child: Row(
              mainAxisSize: MainAxisSize.min, // Wykorzystujemy minimalną przestrzeń
              children: [
                Text(
                  prefixText,
                  style: const TextStyle(color: Colors.black, fontWeight: FontWeight.bold),
                ),
                // Możesz dodać odstęp między tekstem a wpisywanym tekstem jeśli jest potrzebny
              ],
            ),
          ),
          // Brak paddingu z lewej strony, więc tekst wpisywany będzie się zaczynał zaraz za prefixIcon
          contentPadding: EdgeInsets.only(bottom: 12, left: 0),
        ),
        cursorColor: Colors.black,
      ),
    );
  }
}
