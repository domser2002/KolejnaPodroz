import 'package:flutter/material.dart';

class SocialButton extends StatelessWidget {
  final String text;
  final String logo;
  final Color color;
  final Color textColor;
  final VoidCallback onPressed;

  const SocialButton({
    Key? key,
    required this.text,
    required this.logo,
    required this.color,
    required this.textColor,
    required this.onPressed,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return ElevatedButton.icon(
      icon: Image.asset(logo, height: 18),
      label: Text(text),
      onPressed: onPressed,
      style: ElevatedButton.styleFrom(
        backgroundColor: color,
        foregroundColor: textColor,
        minimumSize:const  Size(double.infinity, 50),
      ),
    );
  }
}
