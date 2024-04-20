import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:frontend/cubits/payment_cubit/payment_state.dart';
import 'package:http/http.dart' as http;


class PaymentCubit extends Cubit<PaymentState> {
  final String host;

  PaymentCubit({required this.host}) : super(PaymentState());

  Future<void> processPayment(String paymentId) async {
    emit(PaymentState(loading: true));
    try {
      var url = Uri.parse('$host/Payment/process/$paymentId');
      var response = await http.post(url);

      if (response.statusCode == 200) {
        emit(PaymentState(message: 'Payment processed successfully'));
      } else {
        emit(PaymentState(error: 'Failed to process payment'));
      }
    } catch (e) {
      emit(PaymentState(error: e.toString()));
    } finally {
      emit(PaymentState(loading: false));
    }
  }
}
