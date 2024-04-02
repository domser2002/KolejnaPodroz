import '../classes/train_offer.dart';
abstract class TrainOffersState {}

class TrainOffersInitial extends TrainOffersState {}

class TrainOffersLoading extends TrainOffersState {}

class TrainOffersLoaded extends TrainOffersState {

  final List<TrainOffer> offers;

  TrainOffersLoaded(this.offers);
}

class TrainOffersError extends TrainOffersState {
  final String message;

  TrainOffersError(this.message);
}
