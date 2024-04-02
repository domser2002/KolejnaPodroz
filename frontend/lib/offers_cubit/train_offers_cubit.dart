import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:frontend/offers_cubit/train_offers_state.dart';

part '../cubits/train_offers_state.dart';

class TrainOffersCubit extends Cubit<TrainOffersState> {
  TrainOffersCubit() : super(TrainOffersInitial());

  void getTrainOffers() {
    // symulacja ładowania ofert
    emit(TrainOffersLoading());
    // Tutaj dodałbyś logikę pobierania danych z backendu
    Future.delayed(Duration(seconds: 2), () {
      // symulacja ładowania danych
      emit(TrainOffersLoaded([/* Lista ofert pociągów */]));
    });
  }
}
